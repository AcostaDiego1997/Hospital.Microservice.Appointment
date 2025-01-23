using Microservice.Appointments.Application.Interfaces.Repository;
using Microservice.Appointments.Infrastructure.Repositories;

namespace Microservice.Appointments.Api.Configuration
{
    public class Repositories_Dependencies
    {
        public Repositories_Dependencies(IServiceCollection services)
        {
            services.AddScoped<IAppointment_Repository, Appointment_Repository>();
        }
    }
}
