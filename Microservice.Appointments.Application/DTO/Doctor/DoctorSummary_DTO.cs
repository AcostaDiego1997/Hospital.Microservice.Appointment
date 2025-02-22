using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Application.DTO.Doctor
{
    public class DoctorSummary_DTO
    {
        public int Id { get; set; }
        public int Credential { get; set; }
        public string FullName { get; set; } = null!;
        public string Specialty { get; set; } = null!;
    }
}
