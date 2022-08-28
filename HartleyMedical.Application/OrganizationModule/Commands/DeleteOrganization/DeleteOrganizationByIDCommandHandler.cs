using AutoMapper;
using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.ILocationRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Commands.DeleteOrganization
{
    public class DeleteOrganizationByIDCommandHandler : IRequestHandler<DeleteOrganizationByIDRequest, bool>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ILocationRepository _locationRepository;
        public DeleteOrganizationByIDCommandHandler(IOrganizationRepository organizationRepository, ILocationRepository locationRepository)
        {
            _organizationRepository = organizationRepository;
            _locationRepository = locationRepository;
        }
        public async Task<bool> Handle(DeleteOrganizationByIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = false;
                Organization organization = _organizationRepository.GetFirst(c => c.ID == request.ID && !c.IsDeleted);
                List<Location> location = _locationRepository.GetMany(c => c.fk_FacilityID == request.ID && !c.IsDeleted).ToList();
                if (organization != null)
                {
                    organization.IsDeleted = true;
                    foreach (var item in location)
                    {
                        item.IsDeleted = true;
                    }
                    _organizationRepository.Complete();
                    result = true;
                }
                else
                {
                    throw new BadRequestException($"Organization '{request.ID}' not found");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
