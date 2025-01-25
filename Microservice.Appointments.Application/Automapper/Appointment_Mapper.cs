using AutoMapper;
using Microservice.Appointments.Application.Commands.Request;
using Microservice.Appointments.Domain.Appointment;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Microservice.Appointments.Application.Automapper
{
    public class Appointment_Mapper : Profile
    {
        public Appointment_Mapper() {

            CreateMap<PostAppointment_Command, Appointment>()
                .ForMember(dest => dest.DoctorId, opt => opt.Ignore())
                .ForMember(dest => dest.PatientId, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Date, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.SetPatientId(src.PatientId);
                    dest.SetDoctorId(src.DoctorId);
                    dest.SetDate(src.Date);
                    dest.SetStatus(true);
                });
                
        }
    }
}
