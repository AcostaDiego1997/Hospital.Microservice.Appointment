using MediatR;
using Microservice.Appointments.Application.DTO.Patient;
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
        private readonly int _patientDni;
        private readonly int _doctorCredential;
        private readonly DateTime _date;

        public PostAppointment_Command(Appointment_DTO dto)
        {
            _patientDni = dto.PatientDni;
            _doctorCredential = dto.DoctorCredential;
            _date = dto.Date;
        }

        public int PatientId { get => _patientDni; }
        public int DoctorId { get => _doctorCredential; }
        public DateTime Date { get => _date; }
    }
}
