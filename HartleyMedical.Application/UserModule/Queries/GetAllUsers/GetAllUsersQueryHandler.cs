using AutoMapper;
using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersRequest, RecordSet<GetAllUsersResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<RecordSet<GetAllUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_userRepository.GetUsers(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

