using HartleyMedical.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.ServicesInterfaces
{
    public interface IEmailService
    {
        bool SendAccountCreatedEmail(User user);
        bool SendForgotPasswordEmail(User user);
    }
}
