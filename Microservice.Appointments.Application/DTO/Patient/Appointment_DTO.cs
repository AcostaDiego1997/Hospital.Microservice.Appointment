using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Application.DTO.Patient
{
    public class Appointment_DTO
    {
        public int PatientDni { get; set; }
        public int DoctorCredential { get; set; }
        public DateTime Date { get; set; }
    }
}
