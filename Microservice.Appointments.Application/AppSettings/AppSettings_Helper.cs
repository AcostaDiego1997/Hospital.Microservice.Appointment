using Microservice.Appointments.Application.AppSettings.Entities;

namespace Microservice.Appointments.Application.AppSettings
{
    public class AppSettings_Helper
    {
        public static string Environment { get; set; } = null!;
        public static string DbConnectionString { get; set; } = null!;
        public static Dictionary<string, string> Services_Urls { get; set; } = null!;
        public static Auth Auth { get; set; } = null!;
    }
}
