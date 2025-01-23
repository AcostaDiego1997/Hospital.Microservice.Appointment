using Microservice.Appointments.Domain.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Appointments.Infrastructure.TableConfig
{
    public class Appointment_TableConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.DoctorId).HasColumnName("DoctorId").IsRequired();
            builder.Property(p => p.PatientId).HasColumnName("PatientId").IsRequired();
            builder.Property(p => p.Date).HasColumnName("Date").HasField("_date");
            builder.Property(p => p.Status).HasColumnName("Status");
        }
    }
}
