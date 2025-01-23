﻿//using Microservice.Appointments.Application.AppSettings;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace Microservice.Appointments.Infrastructure.JWT
//{
//    public class TokenManager
//    {
//        public string CreateToken(Patient patient)
//        {
//            JwtSecurityTokenHandler handler = new();

//            ClaimsIdentity claims = GetClaims(patient);
//            int expire = AppSettings_Helper.Auth.Expire;

//            byte[] secretKey = Encoding.ASCII.GetBytes(AppSettings_Helper.Auth.SecretKey);

//            SecurityTokenDescriptor token = new()
//            {
//                Subject = claims,
//                Expires = DateTime.UtcNow.AddDays(365),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
//                Issuer = AppSettings_Helper.Auth.Issuer,
//                Audience = AppSettings_Helper.Auth.Audience
//            };

//            var output = handler.CreateToken(token);
//            return handler.WriteToken(output);
//        }

//        public bool? ValidateToken(string token)
//        {
//            throw new NotImplementedException();
//        }


//        private ClaimsIdentity GetClaims(Patient patient)
//        {
//            ClaimsIdentity output = new(new[]
//            {
//                new Claim("email", patient.Email.Value),
//                new Claim("dni", patient.Dni.ToString()),
//                new Claim("name", patient.Name),
//                new Claim("lastname", patient.LastName)
//            });

//            return output;
//        }
//    }
//}
