using FluentValidation;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Queries.GetUserDetailsByDEANumber
{

    //public record GetUserDetailsByDEANumberRequest(string DEANumber) : IRequest<GetUserDetailsByIDResponse>;

    public class GetUserDetailsByDEANumberRequest : IRequest<GetUserDetailsByIDResponse>
    {
        public string DEANumber { get; set; }
    }

    public class GetUserDetailsByDEANumberRequestValidator : AbstractValidator<GetUserDetailsByDEANumberRequest>
    {
        public GetUserDetailsByDEANumberRequestValidator()
        {
            RuleFor(x => x.DEANumber)
                .NotEmpty().WithMessage("DEA Number is required");
        }
    }
}
