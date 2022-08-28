using FluentValidation;
using HartleyMedical.Application.Common.CustomValidators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Commands.UpsertLocation
{
    public class UpsertLocationRequest : IRequest<UpsertLocationResponse>
    {
        public int ID { get; set; }
        public string LocationName { get; set; }
        public int OrganizationID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
    }

    public class UpsertLocationRequestValidator : AbstractValidator<UpsertLocationRequest>
    {
        public UpsertLocationRequestValidator()
        {
            RuleFor(c => c.LocationName)
                .NotEmpty().WithMessage("LocationName is required")
                .MaximumLength(50);

            RuleFor(c => c.AddressLine1)
                .NotEmpty().WithMessage("AddressLine1 is required")
                .MaximumLength(50);

            RuleFor(c => c.AddressLine2).MaximumLength(50);

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("City is required")
                .MaximumLength(50);

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("PostalCode is required")
                .MaximumLength(50);

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required")
                .IsPhoneNumber();

            RuleFor(c => c.StateID).NotEmpty().WithMessage("StateID is required");
            RuleFor(c => c.OrganizationID).NotEmpty().WithMessage("OrganizationID is required");

        }
    }
}
