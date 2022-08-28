using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganizationTypes
{
    public class GetAllOrganizationTypesQueryHandler : IRequestHandler<GetAllOrganizationTypesRequest, List<LookupDto>>
    {
        private readonly IOrganizationTypeRepository _organizationTypeRepository;
        public GetAllOrganizationTypesQueryHandler(IOrganizationTypeRepository organizationTypeRepository)
        {
            _organizationTypeRepository = organizationTypeRepository;
        }
        public async Task<List<LookupDto>> Handle(GetAllOrganizationTypesRequest request, CancellationToken cancellationToken)
        {
            var organizationType = await _organizationTypeRepository.GetAll();
            return organizationType.Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.TypeName,
            }).ToList();
        }
    }
}
