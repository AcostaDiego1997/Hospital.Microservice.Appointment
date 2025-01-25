using Microservice.Appointments.Application.AppSettings.Entities;

namespace Microservice.Appointments.Application.AppSettings
{
    public class AppSettings_Helper
    {
        public static string Environment { get; set; } = null!;
        public static ConnectionStrings ConnectionStrings { get; set; } = null!;
        public static Auth Auth { get; set; } = null!;
        public static Services Services { get; set; } = null!;

        public static string GetConnectionString(string env)
        {
            if (env == "dev")
                return ConnectionStrings.Db_Dev;
            if (env == "test")
                return ConnectionStrings.Db_Test;
            if (env == "prod")
                return ConnectionStrings.Db_Prod;

            throw new Exception($"Ocurrio un error al acceder a la base de datos. El ambiente '{Environment}' no tiene una base de datos asignada.");
        }

        public static string GetUrl()
        {
            if (Environment == "dev")
                return Services.Doctor.Url.Dev;
            if (Environment == "test")
                return Services.Doctor.Url.Test;
            if (Environment == "prod")
                return Services.Doctor.Url.Prod;

            throw new Exception($"Ocurrio un error al acceder a la url. El ambiente '{Environment}' no tiene una url asignada.");
        }


        public static Dictionary<string, string> GetEndpoints(bool isDoctor)
        {
            Dictionary<string, string> output = [];
            string url = GetUrl();

            output.Add("Get", (isDoctor) ? $"{url}{Services.Doctor.Endpoint.Get}" : $"{url}{Services.Patient.Endpoint.Get}");
            output.Add("GetAll", (isDoctor) ? $"{url}{Services.Doctor.Endpoint.GetAll}" : $"{url}{Services.Patient.Endpoint.GetAll}");

            return output;

        }
    }
}
