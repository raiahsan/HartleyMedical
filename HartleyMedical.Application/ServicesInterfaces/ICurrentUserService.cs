using HartleyMedical.Application.UserModule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceInterfaces.IUserServices
{
    public interface ICurrentUserService
    {
        string Fullname { get; }
        int UserId { get; }
        UserDto User { get; }
    }
}
