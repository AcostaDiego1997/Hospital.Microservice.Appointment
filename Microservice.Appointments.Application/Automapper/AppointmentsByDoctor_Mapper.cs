using AutoMapper;
using Microservice.Appointments.Application.DTO.Appointment;
using Microservice.Appointments.Application.DTO.Doctor;
using Microservice.Appointments.Application.DTO.Patient;

namespace Microservice.Appointments.Application.Automapper
{
    public class AppointmentsByDoctor_Mapper : Profile
    {
        public AppointmentsByDoctor_Mapper()
        {
            CreateMap<DoctorSummary_DTO, DoctorAppointments_DTO>()
                .ForMember(dest => dest.Doctor_Credential, opt => opt.MapFrom(src => src.Credential))
                .ForMember(dest => dest.Doctor_Name, opt => opt.MapFrom(src => src.FullName));

            CreateMap<PatientSummary_DTO, DoctorAppointmentsDetail_DTO>()
                .ForMember(dest => dest.Patient_Name, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Patient_Dni, opt => opt.MapFrom(src => src.Dni));

            CreateMap<List<PatientSummary_DTO>, List<DoctorAppointmentsDetail_DTO>>()
                    .ConvertUsing((src, dest, context) =>
                    {
                        dest = src.Select(dto => context.Mapper.Map<DoctorAppointmentsDetail_DTO>(dto)).ToList();

                        return dest;
                    });
        }
    }
}
