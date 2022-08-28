using FluentValidation;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Commands.UpsertRole
{
    public class UpsertRoleRequest : IRequest<UpsertRoleResponse>
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public int UserTypeID { get; set; }
        public List<int> ActionToModuleIDs { get; set; }
    }

    public class UpsertRoleRequestValidator : AbstractValidator<UpsertRoleRequest>
    {
        public UpsertRoleRequestValidator()
        {
                RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("RoleName is required")
                .MaximumLength(50);
        }
    }
}
