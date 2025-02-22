using MediatR;
using Microservice.Appointments.Application.Commands.Request;
using Microservice.Appointments.Application.DTO.Appointment;
using Microservice.Appointments.Application.Queries.Request;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Appointments.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("doctor/{id}")]
        public async Task<IActionResult> GetAppointmentsBydoctor(int id)
        {
            try
            {
                DoctorAppointments_DTO? output = await _mediator.Send(new AppointmentsByDoctor_Query(id));

                if (output == null)
                    return NotFound("El doctor no cuenta con citas agendadas.");

                return Ok(output);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Appointment_DTO dto)
        {
            try
            {
                int? output = await _mediator.Send(new PostAppointment_Command(dto));

                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Cita agendada con exito",
                    Entity = dto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
