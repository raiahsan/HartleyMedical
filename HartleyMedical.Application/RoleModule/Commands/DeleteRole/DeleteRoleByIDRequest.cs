using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Commands.DeleteRole
{
    public class DeleteRoleByIDRequest : IRequest<bool>
    {
        public int ID { get; set; }
        public DeleteRoleByIDRequest(int id)
        {
            ID = id;
        }
    }
}
