using AutoMapper;
using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Queries.GetOrganizationByID
{
    public class GetOrganizationByIDHandler : IRequestHandler<GetOrganizationByIDRequest, GetOrganizationByIDResponse>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public GetOrganizationByIDHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }
        public async Task<GetOrganizationByIDResponse> Handle(GetOrganizationByIDRequest request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.Get(request.ID);
            return _mapper.Map<GetOrganizationByIDResponse>(organizations);
        }
    }
}
