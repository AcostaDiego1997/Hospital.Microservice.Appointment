
namespace Microservice.Appointments.Application.DTO.Appointment
{
    public class DoctorAppointmentsDetail_DTO
    {
        public DateTime Date { get; set; }
        public string Patient_Dni { get; set; } = null!;
        public string Patient_Name { get; set; } = null!;
    }
}
