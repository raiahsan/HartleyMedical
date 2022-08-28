using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ValidateResetPasswordLink
{
    public class ValidateResetPasswordLinkRequest : IRequest<ValidateResetPasswordLinkResponse>
    {
        public string Code { get; set; }
    }
    public class ValidateResetPasswordLinkRequestValidator : AbstractValidator<ValidateResetPasswordLinkRequest>
    {
        public ValidateResetPasswordLinkRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
