using FluentValidation;
using HartleyMedical.Application.Common.CustomValidators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ForgotPassword
{
    public class ForgotPasswordRequest : IRequest<bool>
    {
        public string Email { get; set; }
    }

 
}
