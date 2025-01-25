using MediatR;
using Microservice.Appointments.Application.AppSettings;
using Microservice.Appointments.Application.Commands.Request;
using Microservice.Appointments.Application.DTO;
using Microservice.Appointments.Application.DTO.Patient;
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

        [HttpGet("patient/{dni}")]
        public async Task<IActionResult> GetAppointmentsByPatient(int dni)
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

        [HttpGet("doctor/{credential}")]
        public async Task<IActionResult> GetAppointmentsBydoctor(int credential)
        {
            try
            {
                List<DoctorAppointments_DTO> output = await _mediator.Send(new AppointmentsByDoctor_Query(credential));

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
                    Message = "Paciente insertado con exito",
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
