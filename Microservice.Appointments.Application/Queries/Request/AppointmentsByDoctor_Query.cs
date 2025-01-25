using MediatR;
using Microservice.Appointments.Application.DTO;

namespace Microservice.Appointments.Application.Queries.Request
{
    public class AppointmentsByDoctor_Query : IRequest<List<DoctorAppointments_DTO>>
    {
        private readonly int _credential;
        public AppointmentsByDoctor_Query(int credential)
        {
            _credential = credential;   
        }
        public int Credential { get => _credential; }
    }
}
