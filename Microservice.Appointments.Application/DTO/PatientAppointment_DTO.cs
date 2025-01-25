using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Application.DTO
{
    public class PatientAppointment_DTO
    {
        public string Patient_Dni { get; set; } = null!;
        public string Patient_Name { get; set; } = null!;
        public List<PatientAppointmentDetail_DTO> Appointments { get; set; } = null!;
    }

    public class PatientAppointmentDetail_DTO
    {
        public string Specialty { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Doctor_Credential { get; set; } = null!;
        public string Doctor_Name { get; set; } = null!;
    }
}
