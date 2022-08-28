using FluentValidation;
using HartleyMedical.Application.Common.CustomValidators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Commands.CreateOrganization
{
    public class UpsertOrganizationRequest : IRequest<UpsertOrganizationResponse>
    {
        public int ID { get; set; }
        public string FacilityName { get; set; }
        public int OrganizationTypeID { get; set; }
        public string GroupNPI { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public bool Active { get; set; }
    }

    public class CreateOrganizationRequestValidator : AbstractValidator<UpsertOrganizationRequest>
    {
        public CreateOrganizationRequestValidator()
        {
            RuleFor(c => c.FacilityName).NotEmpty().WithMessage("FacilityName is required");

            RuleFor(c => c.OrganizationTypeID).NotEmpty().WithMessage("OrganizationTypeID is required");

            RuleFor(c => c.TaxIdentificationNumber).NotEmpty().WithMessage("TaxIdentificationNumber is required")
                .MaximumLength(50);

            RuleFor(c => c.GroupNPI).NotEmpty().WithMessage("GroupNPI is required")
                .MaximumLength(50);

        }
    }
}
