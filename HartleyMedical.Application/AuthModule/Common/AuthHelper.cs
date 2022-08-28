using HartleyMedical.Application.AuthModule.Commands.ValidateTwoFACode;
using HartleyMedical.Application.Common.Settings;
using HartleyMedical.Application.UserModule.Models;
using HartleyMedical.Domain.Constants;
using HartleyMedical.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Common
{
    public static class AuthHelper
    {
        public static User SetTwoFACode(this User user)
        {
            if (user != null)
            {
                user.TwoFACode = new Random().Next(100000, 999999).ToString();
                user.TwoFACodeRequestDate = DateTime.UtcNow;
            }
            return user;
        }
        public static DateTime GetTwoFACodeExpiryTime(this User user, List<SystemSetting> systemSettings)
        {
            var tokenExpirySettings = systemSettings.Where(c => c.SettingName == SystemSettingsVariables.TwoFACodeExpiryTime).FirstOrDefault();
            if (tokenExpirySettings != null && String.IsNullOrWhiteSpace(tokenExpirySettings.SettingValue))
            {
                return user.TwoFACodeRequestDate.Value.AddMinutes(Convert.ToDouble(tokenExpirySettings.SettingValue));
            }
            else
            {
                return user.TwoFACodeRequestDate.Value.AddMinutes(5);
            }
        }
        public static ValidateTwoFACodeResponse GetAuthToken(this UserDto userDto, AppSettings appSettings)
        {
            ValidateTwoFACodeResponse validateTwoFAResponse = new ValidateTwoFACodeResponse()
            {
                User = userDto
            };
            // Set time for expire token
            DateTime tokenExpiryTime = DateTime.UtcNow;
            tokenExpiryTime = tokenExpiryTime.AddMinutes(appSettings.JwtTokenExpireInMinute ?? 60); // TODO : move to appsettings
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Secret); // TODO : move to appsettings

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                                new Claim(ClaimTypes.NameIdentifier, userDto.ID.ToString()),
                                new Claim(ClaimTypes.Name, userDto.FirstName + " " + userDto.LastName),
                                new Claim(ClaimTypes.Email, userDto.Email),
                                new Claim(ClaimTypes.Actor, userDto.ID.ToString()),
                                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(userDto))
                }),
                Expires = tokenExpiryTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //if (userDto.Role != null)
            //{
            //    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, userDto.Role));
            //}
           
            var token = tokenHandler.CreateToken(tokenDescriptor);
            validateTwoFAResponse.AccessToken = tokenHandler.WriteToken(token);
            validateTwoFAResponse.RequestedServerUtcNow = DateTime.UtcNow;
            validateTwoFAResponse.ExpiresAt = tokenExpiryTime;
            return validateTwoFAResponse;
        } 
    }
}
