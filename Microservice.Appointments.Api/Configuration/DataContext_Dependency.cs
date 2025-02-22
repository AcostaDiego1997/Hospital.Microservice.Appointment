using Microservice.Appointments.Application.AppSettings;
using Microservice.Appointments.Application.AppSettings.Entities;
using Microservice.Appointments.Application.Interfaces.DataContext;
using Microservice.Appointments.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Microservice.Appointments.Api.Configuration
{
    public class DataContext_Dependency
    {
        public DataContext_Dependency(IServiceCollection services, AppSettings settings)
        {
            string conn = AppSettings_Helper.DbConnectionString;


            services.AddDbContext<DataContext>(options => options.UseSqlServer(conn)
             .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine));

            services.AddScoped<IDbContextTransaction>(sp =>
            {
                var dataContext = sp.GetRequiredService<DataContext>();
                return dataContext.Database.BeginTransaction();
            });

            services.AddScoped<IDataContext, DataContext>();
        }
    }
}
