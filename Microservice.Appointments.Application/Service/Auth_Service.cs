//using Microservice.Appointments.Application.Interfaces.JWT;
//using Microservice.Appointments.Application.Interfaces.Service;
//using Microservice.Appointments.Application.Interfaces.UnitOfWork;
//using Microservice.Appointments.Domain.Appointment;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Microservice.Appointments.Application.Service
//{
//    public class Auth_Service : IAuth_Service
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IToken _tokenService;

//        public Auth_Service(IUnitOfWork unitOfWork, IToken tokenService)
//        {
//            _unitOfWork = unitOfWork;
//            _tokenService = tokenService;
//        }

//        public async Task<string> CreateTokenAsync(string email, string pass)
//        {
//            try
//            {
//                Appointment? patient = _unitOfWork.Appointment_Repository.GetByEmail(email) ?? throw new ArgumentException($"No se encuentra un paciente con el email '{email}'");

//                ValidatePassword(patient.Password.Value, pass);

//                string output = _tokenService.CreateToken(patient);

//                return output;
//            }
//            catch (Exception ex)
//            {
//                await _unitOfWork.RollBackTransactionAsync();
//                throw new Exception(ex.Message);
//            }
//        }

//        public bool? ValidateToken(string token)
//        {
//            throw new NotImplementedException();
//        }

//        private void ValidatePassword(string passInDb, string passDto)
//        {
//            if (passInDb != passDto)
//                throw new ArgumentException("Los datos ingresados son incorrectos.");
//        }

//    }
//}
