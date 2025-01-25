using Microservice.Appointments.Application.Automapper;

namespace Microservice.Appointments.Api.Configuration
{
    public class AutoMapper_Config
    {
        public AutoMapper_Config(IServiceCollection services)
        {
            services.AddAutoMapper(prf =>
            {
                prf.AddProfile<Appointment_Mapper>();
            });
        }
    }
}
