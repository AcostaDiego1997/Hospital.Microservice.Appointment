using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Application.DTO
{
    public class DoctorAppointments_DTO
    {
        public class DoctorAppointment_DTO
        {
            public string Doctor_Credential { get; set; } = null!;
            public string Doctor_Name { get; set; } = null!;
            public List<DoctorAppointmentDetail_DTO> Appointments { get; set; } = null!;
        }

        public class DoctorAppointmentDetail_DTO
        {
            public DateTime Date { get; set; }
            public string Patient_Dni { get; set; } = null!;
            public string Patient_Name { get; set; } = null!;
        }
    }
}
