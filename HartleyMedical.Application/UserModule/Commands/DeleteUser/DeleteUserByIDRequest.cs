using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Commands.DeleteUser
{
    public class DeleteUserByIDRequest : IRequest<bool>
    {
        public int ID { get; set; }
        public DeleteUserByIDRequest(int id)
        {
            ID = id; 
        }

    }
}
