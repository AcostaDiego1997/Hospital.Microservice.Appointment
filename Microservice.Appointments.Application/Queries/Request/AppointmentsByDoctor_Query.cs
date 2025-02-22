using MediatR;
using Microservice.Appointments.Application.DTO.Appointment;

namespace Microservice.Appointments.Application.Queries.Request
{
    public class AppointmentsByDoctor_Query : IRequest<DoctorAppointments_DTO?>
    {
        private readonly int _id;
        public AppointmentsByDoctor_Query(int id)
        {
            _id = id;   
        }
        public int Id { get => _id; }
    }
}
