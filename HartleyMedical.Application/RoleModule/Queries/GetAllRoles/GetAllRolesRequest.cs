using HartleyMedical.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Queries.GetAllRoles
{
    public class GetAllRolesRequest : IRequest<List<GetAllRolesResponse>>
    {
        public int? UserTypeID { get; set; }
        public bool? Active { get; set; }

    }
}
