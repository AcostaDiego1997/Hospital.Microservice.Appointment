using Microservice.Appointments.Application.DTO;
using Microservice.Appointments.Application.Interfaces.Repository;
using Microservice.Appointments.Domain.Appointment;
using Microservice.Appointments.Infrastructure.Context;

namespace Microservice.Appointments.Infrastructure.Repositories
{
    public class Appointment_Repository : IAppointment_Repository
    {
        private DataContext _dataContext;

        public Appointment_Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Appointment appointment)
        {
            _dataContext.Appointments.Add(appointment);
        }

        public int? Delete(int doctorId, int patientId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment? Get(int doctorId, int patientId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetByDoctor(int doctorId)
        {
            return _dataContext.Appointments.Where(app => app.DoctorId == doctorId).ToList();
        }

        public List<Appointment> GetByPatient(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
