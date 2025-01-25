using AutoMapper;
using MediatR;
using Microservice.Appointments.Application.Commands.Request;
using Microservice.Appointments.Application.Interfaces.UnitOfWork;
using Microservice.Appointments.Domain.Appointment;

namespace Microservice.Appointments.Application.Commands.Handlers
{
    public class PostAppointment_CommnadHandler : IRequestHandler<PostAppointment_Command, int?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostAppointment_CommnadHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<int?> Handle(PostAppointment_Command request, CancellationToken cancellationToken)
        {
            try
            {
                Appointment apm = _mapper.Map<Appointment>(request);
                _unitOfWork.Appointment_Repository.Add(apm);
                int? output = _unitOfWork.SaveChanges();
                await _unitOfWork.CommitTransactionAsync();

                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
