using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.Common.Helpers;
using HartleyMedical.Application.RepositoryInterfaces.ILocationRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IStateRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Commands.UpsertLocation
{
    public class UpsertLocationCommandHandler : IRequestHandler<UpsertLocationRequest, UpsertLocationResponse>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ILocationRepository _locationRepository;
        public UpsertLocationCommandHandler(IOrganizationRepository organizationRepository, ILocationRepository locationRepository, IStateRepository stateRepository)
        {
            _organizationRepository = organizationRepository;
            _locationRepository = locationRepository;
            _stateRepository = stateRepository;
        }
        public async Task<UpsertLocationResponse> Handle(UpsertLocationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Location location;
                var organization = await _organizationRepository.Get(request.OrganizationID);
                var state = await _stateRepository.Get(request.StateID);
                if (organization == null)
                {
                    throw new BadRequestException($"OrganizationID '{request.OrganizationID}' not found");
                }
                else if (state == null)
                {
                    throw new BadRequestException($"StateID '{request.StateID}' not found");
                }
                else
                {
                    if (request.ID == 0)
                    {
                        location = new Location
                        {
                            LocationName = request.LocationName,
                            PhoneNumber = request.PhoneNumber.RemoveSpecialCharacters(),
                            AddressLine1 = request.AddressLine1,
                            AddressLine2 = request.AddressLine2,
                            City = request.City,
                            PostalCode = request.PostalCode,
                            fk_StateID = state.ID,
                            fk_FacilityID = organization.ID,
                            IsDeleted = false,
                            Active = organization.Active
                        };
                        await _locationRepository.Add(location);
                    }
                    else
                    {
                        location = await _locationRepository.Get(request.ID);
                        if (location != null)
                        {
                            location.LocationName = request.LocationName;
                            location.PhoneNumber = request.PhoneNumber.RemoveSpecialCharacters();
                            location.AddressLine1 = request.AddressLine1;
                            location.AddressLine2 = request.AddressLine2;
                            location.City = request.City;
                            location.PostalCode = request.PostalCode;
                            location.fk_StateID = state.ID;
                            location.fk_FacilityID = organization.ID;
                            location.IsDeleted = false;
                            location.Active = request.Active;
                        }
                        else
                        {
                            throw new BadRequestException($"ID '{request.ID}' not found");
                        }
                    }
                    _locationRepository.Complete();
                    return new UpsertLocationResponse
                    {
                        ID = location.ID
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    }
