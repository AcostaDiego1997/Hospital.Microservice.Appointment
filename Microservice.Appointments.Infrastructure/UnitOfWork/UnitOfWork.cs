
using Microservice.Appointments.Application.Interfaces.Repository;
using Microservice.Appointments.Application.Interfaces.UnitOfWork;
using Microservice.Appointments.Infrastructure.Context;
using Microservice.Appointments.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Microservice.Appointments.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IAppointment_Repository _appointmentRepository;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DataContext dataContext, IAppointment_Repository appointmentRepository, IDbContextTransaction transaction)
        {
            _dataContext = dataContext;
            _appointmentRepository = appointmentRepository;
            _transaction = transaction;
        }

        public IAppointment_Repository Appointment_Repository => _appointmentRepository ?? new Appointment_Repository(_dataContext);

        public void BeginTransaction()
        {
            if (_transaction != null)
                return;

            _transaction = _dataContext.Database.BeginTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _dataContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await RollBackTransactionAsync();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            if (_transaction != null)
                _transaction.Dispose();
        }

        public async Task RollBackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public int SaveChanges()
        {
            int output = _dataContext.SaveChanges();
            return output;
        }
    }
}

