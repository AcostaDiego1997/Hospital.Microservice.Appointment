using Microservice.Appointments.Application.Interfaces.UnitOfWork;
using Microservice.Appointments.Infrastructure.UnitOfWork;

namespace Microservice.Appointments.Api.Configuration
{
    public class Services_Dependencies
    {
        public Services_Dependencies(IServiceCollection services)
        {
            //services.AddScoped<IAuth_Service, Auth_Service>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IToken, TokenManager>();
        }
    }
}
