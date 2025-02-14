﻿using Microservice.Appointments.Application.AppSettings;
using Microservice.Appointments.Application.AppSettings.Entities;

namespace Microservice.Appointments.Api.Configuration
{
    public class AppSettings_Config
    {
        private readonly AppSettings _appSettings;
        public AppSettings_Config(WebApplicationBuilder? builder) 
        {
            builder.Services.Configure<AppSettings>(builder.Configuration);

            _appSettings = builder.Configuration.Get<AppSettings>() ?? throw new Exception("No fue posible obtener la configuracion de la aplicacion.");

            AppSettings_Helper.Auth = _appSettings.Auth;
            AppSettings_Helper.Environment = _appSettings.Environment;
            AppSettings_Helper.ConnectionStrings = _appSettings.ConnectionStrings;
            AppSettings_Helper.Services = _appSettings.Services;

            builder.Services.AddSingleton(_appSettings);
        }

        public AppSettings AppSettings { get => _appSettings; }
    }
    }

