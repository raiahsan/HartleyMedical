using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Commands.UpsertRole
{
    public class UpsertRoleCommandHandler : IRequestHandler<UpsertRoleRequest, UpsertRoleResponse>
    {
        private readonly IRoleRepository _roleRepository;
        public readonly IRolePermissionRepository _rolePermissionRepository;
        public readonly IActionToModuleRepository _actionToModuleRepository;
        public UpsertRoleCommandHandler(IRoleRepository roleRepository, IRolePermissionRepository rolePermissionRepository, IActionToModuleRepository actionToModuleRepository)
        {
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _actionToModuleRepository = actionToModuleRepository;
        }
        public async Task<UpsertRoleResponse> Handle(UpsertRoleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Role role;
                if (request.ID == 0)
                {
                    role = new Role
                    {
                        RoleName = request.RoleName,
                        Description = request.Description,
                        fk_UserTypeID = request.UserTypeID,
                        Active = request.Active,
                    };
                    await _roleRepository.Add(role);
                    _roleRepository.Complete();
                }
                else
                {
                    role = await _roleRepository.Get(request.ID);
                    if (role != null)
                    {
                        role.RoleName = request.RoleName;
                        role.Description = request.Description;
                        role.fk_UserTypeID = request.UserTypeID;
                        role.Active = request.Active;
                        _roleRepository.Update(role);
                    }
                    else
                    {
                        throw new BadRequestException($"ID '{request.ID}' not found");
                    }
                }
                //_roleRepository.Complete();
                #region Role permission
                request.ActionToModuleIDs = request.ActionToModuleIDs.Distinct().ToList();
                //var role = _roleRepository.GetFirst(c => c.ID == request.RoleID && c.Active);
                var actionModules = await _actionToModuleRepository.GetAll();
                var actionToModule = request.ActionToModuleIDs.Where(id => !actionModules.Any(c => c.ID == id)).ToList();
                if (role == null)
                {
                    throw new BadRequestException($"RoleID '{role.ID}' not found");
                }
                else if (actionToModule.Count > 0)
                {
                    throw new BadRequestException($"ActionToModuleIDs contains invalid ID");
                }
                else
                {
                    var rolePermissionsInDB = _rolePermissionRepository.GetMany(c => c.fk_RoleID == role.ID && c.Active);
                    var rolePermissionsToDelete = rolePermissionsInDB.Where(c => !request.ActionToModuleIDs.Any(id => id == c.fk_ActionToModuleID)).ToList();
                    var rolePermissionsToAdd = request.ActionToModuleIDs.Where(id => !rolePermissionsInDB.Any(c => c.fk_ActionToModuleID == id)).ToList();

                    foreach (var item in rolePermissionsToDelete)
                    {
                        _rolePermissionRepository.Delete(item);
                    }
                    foreach (var item in rolePermissionsToAdd)
                    {
                        await _rolePermissionRepository.Add(new RolePermission
                        {
                            Active = true,
                            fk_ActionToModuleID = item,
                            fk_RoleID = role.ID
                        });
                    }
                    _rolePermissionRepository.Complete();
                }
                #endregion
               
                return new UpsertRoleResponse
                {
                    ID = role.ID
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
