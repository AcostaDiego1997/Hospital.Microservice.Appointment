using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Domain.Appointment
{
    public class Appointment
    {
        private int _id;
        private int _doctorId;
        private int _patientId;
        private DateTime _date;
        private bool _status;

        public Appointment()
        {
            _status = true;
        }

        public Appointment(int doctorId, int patientId, DateTime date)
        {
            _doctorId = doctorId;
            _patientId = patientId;
            _date = date;
            _status = true;
        }

        public int Id { get => _id; }
        public int DoctorId { get => _doctorId; }
        public int PatientId { get => _patientId; }
        public DateTime Date { get => _date; }
        public bool Status { get => _status; }
        public void SetPatientId(int newPatientId) { _patientId = newPatientId; }
        public void SetDoctorId(int newDoctortId) { _doctorId = newDoctortId; }
        public void SetDate(DateTime newDate) { _date = newDate; }
        public void SetStatus(bool newStatus) { _status = newStatus; }


    }
}
