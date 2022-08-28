using AutoMapper;
using HartleyMedical.Application.LocationModule.Queries.GetAllLoctaions;
using HartleyMedical.Application.RepositoryInterfaces.ILocationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Queries.GetAllLoctions
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsRequest, List<GetAllLocationsResponse>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public GetAllLocationsQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public Task<List<GetAllLocationsResponse>> Handle(GetAllLocationsRequest request, CancellationToken cancellationToken)
        {
            var loctions = _locationRepository.GetMany(c => !request.Active.HasValue || c.Active == request.Active, c => c.Facility, c => c.State);
            return Task.FromResult(_mapper.Map<List<GetAllLocationsResponse>>(loctions));
        }
    }
}
