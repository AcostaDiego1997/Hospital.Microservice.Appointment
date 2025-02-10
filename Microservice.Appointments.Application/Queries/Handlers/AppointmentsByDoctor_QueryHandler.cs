using AutoMapper;
using MediatR;
using Microservice.Appointments.Application.AppSettings;
using Microservice.Appointments.Application.DTO;
using Microservice.Appointments.Application.DTO.Doctor;
using Microservice.Appointments.Application.DTO.Patient;
using Microservice.Appointments.Application.Interfaces.UnitOfWork;
using Microservice.Appointments.Application.Queries.Request;
using Microservice.Appointments.Domain.Appointment;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;

namespace Microservice.Appointments.Application.Queries.Handlers
{
    public class AppointmentsByDoctor_QueryHandler : IRequestHandler<AppointmentsByDoctor_Query, List<DoctorAppointments_DTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        private List<DoctorAppointments_DTO> _output;
        private Doctor_DTO _doctor;
        private Patient_DTO _patient;
        private readonly Dictionary<string, string> _docEndpoints;
        private readonly Dictionary<string, string> _patEndpoints;

        public AppointmentsByDoctor_QueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _output = [];
            _doctor = new();
            _patient = new();
            _docEndpoints = AppSettings_Helper.GetEndpoints(true);
            _patEndpoints = AppSettings_Helper.GetEndpoints(false);
        }

        public async Task<List<DoctorAppointments_DTO>> Handle(AppointmentsByDoctor_Query request, CancellationToken cancellationToken)
        {

            // obtengo los pacientes asociados al doctor
            List<Appointment> _appointmentsList = _unitOfWork.Appointment_Repository.GetByDoctor(request.Credential);

            if(_appointmentsList.Count == 0)
                return [];

            _docEndpoints.TryGetValue("Get", out string docGet);
            _patEndpoints.TryGetValue("Summary", out string patGet);

            HttpClient client = new();
            string url = docGet + request.Credential;

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();

                    HttpResponse_DTO<Doctor_DTO>? test = JsonConvert.DeserializeObject<HttpResponse_DTO<Doctor_DTO>>(res) ?? throw new Exception("Error en solicitud de Doctor");

                    if (!test.IsSuccess)
                        throw new Exception("Error al obtener el Doctor: ");

                    _doctor = test.Entity;

                    var r = $"{patGet}=dnis={string.Join(",", _appointmentsList.Select(ap => ap.PatientDni))}";


                    HttpResponseMessage patResponse = await client.GetAsync($"{patGet}=dnis={string.Join(",",r)}");
                }

                return _output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
