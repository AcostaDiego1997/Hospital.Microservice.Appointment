using AutoMapper;
using MediatR;
using Microservice.Appointments.Application.AppSettings;
using Microservice.Appointments.Application.DTO;
using Microservice.Appointments.Application.DTO.Appointment;
using Microservice.Appointments.Application.DTO.Doctor;
using Microservice.Appointments.Application.DTO.Patient;
using Microservice.Appointments.Application.Helpers;
using Microservice.Appointments.Application.Interfaces.UnitOfWork;
using Microservice.Appointments.Application.Queries.Request;
using Microservice.Appointments.Domain.Appointment;
using System.Net.Http.Json;

namespace Microservice.Appointments.Application.Queries.Handlers
{
    public class AppointmentsByDoctor_QueryHandler : IRequestHandler<AppointmentsByDoctor_Query, DoctorAppointments_DTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClient;

        public AppointmentsByDoctor_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpClientFactory httpClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<DoctorAppointments_DTO?> Handle(AppointmentsByDoctor_Query request, CancellationToken cancellationToken)
        {
            DoctorAppointments_DTO _output = new();
            DoctorSummary_DTO doctorSummary = new(); 
            List<PatientSummary_DTO> patientSummaries = [];

            List<Appointment> appointmentsByDoctor = _unitOfWork.Appointment_Repository.GetByDoctor(request.Id);
            if (appointmentsByDoctor.Count < 1)
                return _output;

            List<string> patientsId = appointmentsByDoctor.Select(x => x.Id.ToString()).Distinct().ToList();

            try
            {
                HttpClient patientClient = _httpClient.CreateClient("Patient");
                string patientSummariesQueryParams = Http_Helper.GetUrlWithQueryParams("id", patientsId);
                AppSettings_Helper.Services_Urls.TryGetValue("PatientSummariesEndpoint", out string patientSummariesEndpoint);
                Task<HttpResponseMessage> patientResult = patientClient.GetAsync($"{patientSummariesEndpoint}{patientSummariesQueryParams}");

                HttpClient doctorClient = _httpClient.CreateClient("Doctor");
                Task<HttpResponseMessage> doctorResult = doctorClient.GetAsync($"/api/Doctor/{request.Id}");

                HttpResponseMessage? docResult = await doctorResult;
                HttpResponseMessage? patResult = await patientResult;

                if (docResult == null || patResult == null)
                    throw new Exception("Temporalmente no es posible obtener las citas del doctor.");

                if (!docResult.IsSuccessStatusCode || !patResult.IsSuccessStatusCode)
                    throw new Exception($"Ocurrio un error al obtener las citas del Doctor.");

                var docRespDTO = docResult.Content.ReadFromJsonAsync<HttpResponse_DTO<DoctorSummary_DTO>>();
                var patRespDTO = patResult.Content.ReadFromJsonAsync<HttpResponse_DTO<List<PatientSummary_DTO>>>();

                HttpResponse_DTO<DoctorSummary_DTO>? docRespResult = await docRespDTO;
                HttpResponse_DTO<List<PatientSummary_DTO>>? patRespResult = await patRespDTO;

                if(docRespResult == null || !docRespResult.IsSuccess && docRespResult.Entity == null)
                    throw new Exception($"Error al obtener el detalle del Doctor.");
                if (patRespResult == null || !patRespResult.IsSuccess && patRespResult.Entity == null)
                    throw new Exception($"Error al obtener los pacientes del Doctor.");

                doctorSummary = docRespResult.Entity;
                patientSummaries = patRespResult.Entity;

                _output = _mapper.Map<DoctorAppointments_DTO>(doctorSummary);
                _output.Appointments = _mapper.Map<List<DoctorAppointmentsDetail_DTO>>(patientSummaries);

                return _output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
