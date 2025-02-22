namespace Microservice.Appointments.Application.DTO.Appointment
{
    public class Appointment_DTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
