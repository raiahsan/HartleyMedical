using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Application.RoleModule.Queries.GetUserPermissionsByRoleID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Queries.GetPermissionsByRoleID
{
    public class GetUserPermissionsByRoleIDQueryHandler : IRequestHandler<GetUserPermissionsByRoleIDRequest, List<GetUserPermissionsByRoleIDResponse>>
    {
        public readonly IRoleRepository _roleRepository;
        public GetUserPermissionsByRoleIDQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Task<List<GetUserPermissionsByRoleIDResponse>> Handle(GetUserPermissionsByRoleIDRequest request, CancellationToken cancellationToken)
        {
            if (request.RoleID.HasValue && request.RoleID != 0 && _roleRepository.GetFirst(c => c.ID == request.RoleID && c.Active) == null)
            {
                throw new BadRequestException($"RoleID '{request.RoleID}' not found");
            }
            else
            {
                var result = _roleRepository.GetPermissionsByRoleID(request.RoleID ?? 0, true)
                      .Select(c => new GetUserPermissionsByRoleIDResponse
                      {
                          Action = c.ActionName,
                          Subject = c.ModuleName
                      }).ToList();
                return Task.FromResult(result);
            }
        }
    }
}
