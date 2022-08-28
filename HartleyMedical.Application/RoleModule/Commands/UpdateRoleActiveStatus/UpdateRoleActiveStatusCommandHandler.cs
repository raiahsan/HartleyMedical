using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Commands.UpdateRoleActiveStatus
{
    public class UpdateRoleActiveStatusCommandHandler : IRequestHandler<UpdateRoleActiveStatusRequest, bool>
    {
        private readonly IRoleRepository _roleRepository;
        public UpdateRoleActiveStatusCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<bool> Handle(UpdateRoleActiveStatusRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = false;
                Role role = await _roleRepository.Get(request.ID);
                if (role != null)
                {
                    role.Active = request.Active;
                    _roleRepository.Complete();
                    result = true;
                }
                else
                {
                    throw new BadRequestException($"Role with ID '{request.ID}' not found");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
