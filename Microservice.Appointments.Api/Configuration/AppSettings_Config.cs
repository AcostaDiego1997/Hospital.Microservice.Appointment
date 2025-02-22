using Microservice.Appointments.Application.AppSettings;
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


            AppSettings_Helper.DbConnectionString = GetDbConnectionString(_appSettings);

            AppSettings_Helper.Services_Urls = GetServices(_appSettings);

            builder.Services.AddSingleton(_appSettings);
        }

        public AppSettings AppSettings { get => _appSettings; }


        private Dictionary<string, string> GetServices(AppSettings settings)
        {
            Dictionary<string, string> output = new();
            string doctorUrl = GetServiceUrlAccordingEnv(settings.Services.Doctor.Url, settings.Environment);
            string patientUrl = GetServiceUrlAccordingEnv(settings.Services.Patient.Url, settings.Environment);

            string doctorSummariesEndpoint = settings.Services.Doctor.Endpoint_Doctor.Summaries;
            string patientSummariesEndpoint = settings.Services.Patient.Endpoint_Patient.Summaries;

            output.Add("Doctor", doctorUrl);
            output.Add("DoctorSummariesEndpoint", doctorSummariesEndpoint);
            output.Add("Patient", patientUrl);
            output.Add("PatientSummariesEndpoint", patientSummariesEndpoint);



            return output;
        }

        private string GetServiceUrlAccordingEnv(Url url, string env)
        {
            string output = "";
            switch(env)
            {
                case "dev":
                    output = url.Dev;
                    break;
                case "test":
                    output = url.Test;
                    break;
                case "prod":
                    output = url.Prod;
                    break;
                }
            return output;    
        }


        private string GetDbConnectionString(AppSettings settings)
        {
            string output = "";
            switch (settings.Environment)
            {
                case "dev":
                    output = settings.ConnectionStrings.Db_Dev;
                    break;
                case "test":
                    output = settings.ConnectionStrings.Db_Test;
                    break;
                case "prod":
                    output = settings.ConnectionStrings.Db_Prod;
                    break;
            }

            return output;
        }

    }
    }

