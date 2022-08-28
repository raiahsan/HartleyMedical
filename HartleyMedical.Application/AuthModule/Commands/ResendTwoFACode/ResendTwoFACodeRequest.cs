using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ResendTwoFACode
{
    public class ResendTwoFACodeRequest : IRequest<ResendTwoFACodeResponse>
    {
        public int UserID { get; set; }
    }

    public class ResendTwoFACodeRequestValidator : AbstractValidator<ResendTwoFACodeRequest>
    {
        public ResendTwoFACodeRequestValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().WithMessage("UserID is required");
        }
    }
}
