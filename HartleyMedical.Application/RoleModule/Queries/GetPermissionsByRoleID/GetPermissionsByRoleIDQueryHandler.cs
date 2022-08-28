using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Queries.GetPermissionsByRoleID
{
    public class GetPermissionsByRoleIDQueryHandler : IRequestHandler<GetPermissionsByRoleIDRequest, List<GetPermissionsByRoleIDResponse>>
    {
        public readonly IRoleRepository _roleRepository;
        public GetPermissionsByRoleIDQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Task<List<GetPermissionsByRoleIDResponse>> Handle(GetPermissionsByRoleIDRequest request, CancellationToken cancellationToken)
        {
            if (request.RoleID.HasValue && request.RoleID != 0 && _roleRepository.GetFirst(c => c.ID == request.RoleID && c.Active) == null)
            {
                throw new BadRequestException($"RoleID '{request.RoleID}' not found");
            }
            else
            {
                List<GetPermissionsByRoleIDResponse> result = new List<GetPermissionsByRoleIDResponse>();
                var permissions = _roleRepository.GetPermissionsByRoleID(request.RoleID).GroupBy(c => c.ModuleID);
                foreach (var item in permissions)
                {
                    var module = new GetPermissionsByRoleIDResponse
                    {
                        ModuleID = item.Key,
                        ModuleName = item.FirstOrDefault()?.ModuleName,
                        IsAllowed = !item.Any(c => !c.IsAllowed)
                    };
                    foreach (var action in item)
                    {
                        module.Actions.Add(new GetActionPermissions
                        {
                            ActionID = action.ActionID,
                            ActionName = action.ActionName,
                            ActionToModuleID = action.ActionToModuleID,
                            IsAllowed = action.IsAllowed,
                            RolePermissionID = action.RolePermissionID
                        });
                    }
                    result.Add(module);
                }
                return Task.FromResult(result);
            }
        }
    }
}
