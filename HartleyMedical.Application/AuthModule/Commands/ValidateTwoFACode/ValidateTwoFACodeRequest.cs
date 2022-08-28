using FluentValidation;
using HartleyMedical.Application.UserModule.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ValidateTwoFACode
{
    public class ValidateTwoFACodeRequest : IRequest<Object>
    {
        public int UserID { get; set; }
        public string Code { get; set; }
        public bool IsLoginRequest { get; set; }
    }

    public class ValidateTwoFACodeRequestValidator : AbstractValidator<ValidateTwoFACodeRequest>
    {
        public ValidateTwoFACodeRequestValidator()
        {
            RuleFor(x => x.UserID)
                .NotEmpty().WithMessage("UserID is required");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
