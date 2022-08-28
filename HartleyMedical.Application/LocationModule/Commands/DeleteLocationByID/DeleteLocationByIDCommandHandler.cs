using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.ILocationRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Commands.DeleteLocationByID
{
    public class DeleteLocationByIDCommandHandler : IRequestHandler<DeleteLocationByIDRequest, bool>
    {
        private readonly ILocationRepository _locationRepository;
        public DeleteLocationByIDCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Task<bool> Handle(DeleteLocationByIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = false;
                Location location = _locationRepository.GetFirst(c => c.ID == request.ID && !c.IsDeleted);
                if (location != null)
                {
                    location.IsDeleted = true;
                    _locationRepository.Complete();
                    result = true;
                }
                else
                {
                    throw new BadRequestException($"Location '{request.ID}' not found");
                }
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
