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
            List<Appointment> _appointmentsList = _unitOfWork.Appointment_Repository.GetByDoctor(request.Credential);

            _docEndpoints.TryGetValue("Get", out string docGet);
            _patEndpoints.TryGetValue("Get", out string patGet);

            HttpClient client = new();
            string url = docGet + request.Credential;

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();

                    var test = JsonConvert.DeserializeObject<HttpResponse_DTO>(res);
                    if (test.IsSuccess && test.Entity is Doctor_DTO doctorDto)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        // Manejar casos de error (IsSuccess == false o Entity no es Doctor_DTO)
                        throw new Exception("Error al obtener el Doctor: ");
                    }
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
