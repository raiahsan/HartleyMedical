using AutoMapper;
using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.ExternalDependencies;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID
{
    public class GetUserDetailsByIDQueryHandler : IRequestHandler<GetUserDetailsByIDRequest, GetUserDetailsByIDResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IFileService _fileService;

        public GetUserDetailsByIDQueryHandler(IUserRepository userRepository, IMapper mapper, IMediator mediator, IFileService fileService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mediator = mediator;
            _fileService = fileService;
        }

        public Task<GetUserDetailsByIDResponse> Handle(GetUserDetailsByIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var User = _userRepository.GetUserDetailsByID(request);
                //_fileService.GetFile(User.DEACertificateUrl, "deacertificates");
                return Task.FromResult(User);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

