using Microservice.Appointments.Application.Interfaces.DataContext;
using Microservice.Appointments.Domain.Appointment;
using Microservice.Appointments.Infrastructure.TableConfig;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Appointments.Infrastructure.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Appointment> Appointments {  get; set; }
      

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Appointment_TableConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
