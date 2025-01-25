using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Application.AppSettings.Entities
{
    public class Services
    {
        public Doctor Doctor { get; set; } = null!;
        public Patient Patient { get; set; } = null!;
    }

    public class Doctor
    {
        public Url Url { get; set; } = null!;
        public Endpoint Endpoint { get; set; } = null!;
    }
    public class Patient
    {
        public Url Url { get; set; } = null!;
        public Endpoint Endpoint { get; set; } = null!;
    }

    public class Url
    {
        public string Dev { get; set; } = null!;
        public string Test { get; set; } = null!;
        public string Prod { get; set; } = null!;
    }
    public class Endpoint
    {
        public string Get { get; set; } = null!;
        public string GetAll { get; set; } = null!;
    }
}
