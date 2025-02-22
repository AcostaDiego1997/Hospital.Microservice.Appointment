using MediatR;
using Microservice.Appointments.Application.DTO.Appointment;
using Microservice.Appointments.Domain.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Application.Commands.Request
{
    public class PostAppointment_Command : IRequest<int?>
    {
        private readonly int _patientId;
        private readonly int _doctorId;
        private readonly DateTime _date;

        public PostAppointment_Command(Appointment_DTO dto)
        {
            _patientId = dto.PatientId;
            _doctorId = dto.DoctorId;
            _date = dto.Date;
        }

        public int PatientId { get => _patientId; }
        public int DoctorId { get => _doctorId; }
        public DateTime Date { get => _date; }
    }
}
