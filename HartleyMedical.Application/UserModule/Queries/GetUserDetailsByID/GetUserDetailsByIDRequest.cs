using FluentValidation;
using HartleyMedical.Application.Common.CustomValidators;
using HartleyMedical.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID
{
    public class GetUserDetailsByIDRequest : IRequest<GetUserDetailsByIDResponse>
    {
        public int UserID { get; set; }
    }

    public class GetUserDetailsByIDRequestValidator : AbstractValidator<GetUserDetailsByIDRequest>
    {
        public GetUserDetailsByIDRequestValidator()
        {
            RuleFor(x => x.UserID)
                .NotEmpty().WithMessage("UserId is required");
        }
    }
}
