using FluentValidation;
using HartleyMedical.Application.RoleModule.Queries.GetUserPermissionsByRoleID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Queries.GetPermissionsByRoleID
{
    public class GetPermissionsByRoleIDRequest : IRequest<List<GetPermissionsByRoleIDResponse>>
    {
        public int? RoleID { get; set; }
    }
    //public class GetPermissionsByRoleIDRequestValidator : AbstractValidator<GetPermissionsByRoleIDRequest>
    //{
    //    public GetPermissionsByRoleIDRequestValidator()
    //    {
    //        RuleFor(x => x.RoleID).NotEmpty().WithMessage("RoleID is required");
    //    }
    //}
}
