using Microservice.Appointments.Domain.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Appointments.Application.Interfaces.JWT
{
    public interface IToken
    {
        string CreateToken(Appointment appointment);
        bool? ValidateToken(string token);
    }
}
