using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Commands.UpdateOrganizationActiveStatus
{
    public class UpdateOrganizationActiveStatusCommandHandler : IRequestHandler<UpdateOrganizationActiveStatusRequest, bool>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IOrganizationTypeRepository _organizationTypeRepository;
        public UpdateOrganizationActiveStatusCommandHandler(IOrganizationRepository organizationRepository, IOrganizationTypeRepository organizationTypeRepository)
        {
            _organizationRepository = organizationRepository;
            _organizationTypeRepository = organizationTypeRepository;
        }
        public async Task<bool> Handle(UpdateOrganizationActiveStatusRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = false;
                Organization organization = await _organizationRepository.Get(request.ID);
                if (organization != null)
                {
                    organization.Active = request.Active;
                    _organizationRepository.Complete();
                    result = true;
                }
                else
                {
                    throw new BadRequestException($"Organization with ID '{request.ID}' not found");
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
