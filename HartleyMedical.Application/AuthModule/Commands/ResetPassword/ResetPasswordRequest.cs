using FluentValidation;
using HartleyMedical.Application.Common.CustomValidators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ResetPassword
{
    public class ResetPasswordRequest : IRequest<bool>
    {
        public string Code { get; set; }
        public string Password { get; set; }
    }

    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
                //.IsPassword();
        }
    }
}
