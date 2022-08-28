using AutoMapper;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Queries.GetUserDetailsByDEANumber
{
    public class GetUserDetailsByDEANumberQueryHandler : IRequestHandler<GetUserDetailsByDEANumberRequest, GetUserDetailsByIDResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserDetailsByDEANumberQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<GetUserDetailsByIDResponse> Handle(GetUserDetailsByDEANumberRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_userRepository.GetUserDetailsByDEANumber(request.DEANumber));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
