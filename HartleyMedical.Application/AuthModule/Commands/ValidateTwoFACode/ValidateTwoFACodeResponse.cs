using HartleyMedical.Application.UserModule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HartleyMedical.Application.AuthModule.Commands.ValidateTwoFACode
{
    public class ValidateTwoFACodeResponse
    {
        public string AccessToken { get; set; }
        public UserDto User { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime RequestedServerUtcNow { get; set; }
    }
}
