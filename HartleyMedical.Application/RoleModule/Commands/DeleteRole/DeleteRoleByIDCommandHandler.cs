using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using MediatR;

namespace HartleyMedical.Application.RoleModule.Commands.DeleteRole
{
    public class DeleteRoleByIDCommandHandler : IRequestHandler<DeleteRoleByIDRequest, bool>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserToOrganizationRoleRepository _userToOrganizationRoleRepository;
        public DeleteRoleByIDCommandHandler(IRoleRepository roleRepository, IUserToOrganizationRoleRepository userToOrganizationRoleRepository)
        {
            _roleRepository = roleRepository;
            _userToOrganizationRoleRepository = userToOrganizationRoleRepository;
        }
        public Task<bool> Handle(DeleteRoleByIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = false;
                int associatedUsersCount = _userToOrganizationRoleRepository.GetMany(x => x.fk_RoleID == request.ID).Count();
                if (associatedUsersCount > 0)
                {
                    throw new InvalidOperationException($"The role you are trying to delete is associated with '{associatedUsersCount}' user(s). Kindly remove association before deleting this Role.");
                }
                var role = _roleRepository.GetFirst(c => c.ID == request.ID && !c.IsDeleted);
                if (role != null)
                {
                    role.IsDeleted = true;
                    _roleRepository.Complete();
                    result = true;
                }
                else
                {
                    throw new BadRequestException($"Role '{request.ID}' not found");
                }
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
