using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Queries.GetUserPermissionsByRoleID
{
    public class GetUserPermissionsByRoleIDRequest : IRequest<List<GetUserPermissionsByRoleIDResponse>>
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
