﻿using Microservice.Appointments.Application.Queries.Handlers;

namespace Microservice.Appointments.Api.Configuration
{
    public class Mediatr_Config
    {
        public Mediatr_Config(IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(AppointmentsByDoctor_QueryHandler));
            });
        }
    }
}
