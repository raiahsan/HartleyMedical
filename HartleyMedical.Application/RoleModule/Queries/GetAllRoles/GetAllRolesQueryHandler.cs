using AutoMapper;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using MediatR;

namespace HartleyMedical.Application.RoleModule.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesRequest, List<GetAllRolesResponse>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllRolesQueryHandler(IRoleRepository roleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public Task<List<GetAllRolesResponse>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            var roles = _roleRepository.GetMany(c => (!request.Active.HasValue || c.Active == request.Active) &&(!request.UserTypeID.HasValue || c.fk_UserTypeID == request.UserTypeID),c=> c.UserToOrganizations);
            var rolesList = _mapper.Map<List<GetAllRolesResponse>>(roles);
            var superAdminRoleIndex = rolesList.FindIndex(c => c.ID == 1);
            if (superAdminRoleIndex != -1)
            {
                var userTypeIDForSuperAdmin = 3;
                rolesList[superAdminRoleIndex].ActiveUsers = _userRepository.GetMany(x => x.fk_UserTypeID == userTypeIDForSuperAdmin && x.Active == true).Count();
                rolesList[superAdminRoleIndex].InActiveUsers = _userRepository.GetMany(x => x.fk_UserTypeID == userTypeIDForSuperAdmin && x.Active == false).Count();
            }
            return Task.FromResult(rolesList);
        }
    }
}
