using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.ILocationRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Commands.UpdateLocationActiveStatus
{
    public class UpdateLocationActiveStatusCommandHandler : IRequestHandler<UpdateLocationActiveStatusRequest, bool>
    {
        private readonly ILocationRepository _locationRepository;
        public UpdateLocationActiveStatusCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<bool> Handle(UpdateLocationActiveStatusRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = false;
                Location location = await _locationRepository.Get(request.ID);
                if (location != null)
                {
                    location.Active = request.Active;
                    _locationRepository.Complete();
                    result = true;
                }
                else
                {
                    throw new BadRequestException($"Location with ID '{request.ID}' not found");
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
