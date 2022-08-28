using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Queries.GetAllUserTypes
{
    public class GetAllUserTypesQueryHandler : IRequestHandler<GetAllUserTypesRequest, List<LookupDto>>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public GetAllUserTypesQueryHandler(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<List<LookupDto>> Handle(GetAllUserTypesRequest request, CancellationToken cancellationToken)
        {
            var userTypes = await _userTypeRepository.GetAll();
            return userTypes.Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Type
            }).ToList();
        }
    }
}
