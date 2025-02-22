
namespace Microservice.Appointments.Application.DTO.Appointment
{
    public class DoctorAppointments_DTO
    {
        public string Doctor_Credential { get; set; } = null!;
        public string Doctor_Name { get; set; } = null!;
        public List<DoctorAppointmentsDetail_DTO> Appointments { get; set; } = null!;
    }
}
