using AutoMapper;
using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganization
{
    public class GetAllOrganizationsQueryHandler : IRequestHandler<GetAllOrganizationsRequest, List<GetAllOrganizationsResponse>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public GetAllOrganizationsQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public Task<List<GetAllOrganizationsResponse>> Handle(GetAllOrganizationsRequest request, CancellationToken cancellationToken)
        {
            var organizations = _organizationRepository.GetMany(c => (!request.Active.HasValue || c.Active == request.Active) 
            && (!request.OrganizationTypeID.HasValue || c.fk_OrganizationTypeID==request.OrganizationTypeID));
            return Task.FromResult(_mapper.Map<List<GetAllOrganizationsResponse>>(organizations));
        }
    }
}
