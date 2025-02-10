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
        private int _doctorCredential;
        private int _patientDni;
        private DateTime _date;
        private bool _status;

        public Appointment()
        {
            _status = true;
        }

        public Appointment(int doctorCredential, int patientDni, DateTime date)
        {
            _doctorCredential = doctorCredential;
            _patientDni = patientDni;
            _date = date;
            _status = true;
        }

        public int Id { get => _id; }
        public int DoctorCredential { get => _doctorCredential; }
        public int PatientDni { get => _patientDni; }
        public DateTime Date { get => _date; }
        public bool Status { get => _status; }
        public void SetPatientDni(int newPatientDni) { _patientDni = newPatientDni; }
        public void SetDoctorCredential(int newDoctortCredential) { _doctorCredential = newDoctortCredential; }
        public void SetDate(DateTime newDate) { _date = newDate; }
        public void SetStatus(bool newStatus) { _status = newStatus; }


    }
}
