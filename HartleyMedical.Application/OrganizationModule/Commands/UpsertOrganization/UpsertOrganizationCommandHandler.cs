using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IStateRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Commands.CreateOrganization;

public class UpsertOrganizationCommandHandler : IRequestHandler<UpsertOrganizationRequest, UpsertOrganizationResponse>
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IOrganizationTypeRepository _organizationTypeRepository;
    public UpsertOrganizationCommandHandler(IOrganizationRepository organizationRepository, IOrganizationTypeRepository organizationTypeRepository)
    {
        _organizationRepository = organizationRepository;
        _organizationTypeRepository = organizationTypeRepository;
    }
    public async Task<UpsertOrganizationResponse> Handle(UpsertOrganizationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Organization organization = null;
            var organizationType = await _organizationTypeRepository.Get(request.OrganizationTypeID);
            if (organizationType == null)
            {
                throw new BadRequestException($"OrganizationType '{request.OrganizationTypeID}' not found");
            }
            else
            {
                if (request.ID == 0)
                {
                    organization = new Organization
                    {
                        FacilityName = request.FacilityName,
                        fk_OrganizationTypeID = request.OrganizationTypeID,
                        TaxIdentificationNumber = request.TaxIdentificationNumber,
                        GroupNPI = request.GroupNPI,
                        Active = request.Active,
                    };
                    await _organizationRepository.Add(organization);
                }
                else
                {
                    organization = await _organizationRepository.Get(request.ID);
                    if (organization != null)
                    {
                        organization.FacilityName = request.FacilityName;
                        organization.fk_OrganizationTypeID = request.OrganizationTypeID;
                        organization.TaxIdentificationNumber = request.TaxIdentificationNumber;
                        organization.GroupNPI = request.GroupNPI;
                        organization.Active = request.Active;
                        _organizationRepository.Update(organization);
                    }
                    else
                    {
                        throw new BadRequestException($"Organization with ID '{request.ID}' not found");
                    }
                }
                _organizationRepository.Complete();
            }
            return new UpsertOrganizationResponse
            {
                ID = organization.ID,
                FacilityName = organization.FacilityName,
                GroupNPI = organization.GroupNPI,
                OrganizationTypeID = organization.fk_OrganizationTypeID,
                TaxIdentificationNumber = organization.TaxIdentificationNumber,
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
