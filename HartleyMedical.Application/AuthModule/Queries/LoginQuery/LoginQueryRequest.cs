using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Queries.LoginQuery
{
    public class LoginQueryRequest : IRequest<Object>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginQueryRequestValidator : AbstractValidator<LoginQueryRequest>
    {
        public LoginQueryRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is invalid");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
