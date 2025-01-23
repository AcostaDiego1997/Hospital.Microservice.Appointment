using Microservice.Appointments.Domain.Appointment;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Appointments.Application.Interfaces.DataContext
{
    public interface IDataContext
    {
        DbSet<Appointment> Appointments { get; set; }
    }
}
