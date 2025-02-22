using Microservice.Appointments.Application.AppSettings.Entities;
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

        public int? Delete(int doctorId, int PatientDni, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment? Get(int doctorId, int PatientDni, DateTime date)
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

        public List<Appointment> GetByPatient(int PatientDni)
        {
            throw new NotImplementedException();
        }

        public List<int> GetDoctorsByPatient(int PatientDni)
        {
            return _dataContext.Appointments.Where(app => app.PatientId == PatientDni).Select(app => app.DoctorId).ToList();
        }

        public List<int> GetPatientsByDoctor(int doctorId)
        {
            return _dataContext.Appointments.Where(app => app.DoctorId == doctorId).Select(app => app.PatientId).ToList();
        }
    }
}
