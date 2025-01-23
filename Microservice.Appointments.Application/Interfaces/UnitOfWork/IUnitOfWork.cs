using Microservice.Appointments.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microservice.Appointments.Application.Interfaces.Repository.IAppointment_Repository;

namespace Microservice.Appointments.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        void BeginTransaction();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();

        IAppointment_Repository Appointment_Repository { get; }
    }
}
