using Microservice.Appointments.Application.DTO;
using Microservice.Appointments.Domain.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Application.Interfaces.Repository
{
    public interface IAppointment_Repository
    {
        void Add(Appointment appointment);
        List<Appointment> GetAll();
        Appointment? Get(int doctorId, int patientId, DateTime date);
        //List<Appointment> GetByPatient(int patientId, DateTime date);
        //List<Appointment> GetByDoctor(int doctorId, DateTime date);
        int? Delete(int doctorId, int patientId, DateTime date);
        int UniqueAppointmentValidation(Appointment_DTO dto);
    }
}
