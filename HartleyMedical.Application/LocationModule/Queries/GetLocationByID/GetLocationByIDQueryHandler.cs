using AutoMapper;
using HartleyMedical.Application.RepositoryInterfaces.ILocationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Queries.GetLocationByID
{
    public class GetLocationByIDQueryHandler : IRequestHandler<GetLocationByIDRequest, GetLocationByIDResponse>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public GetLocationByIDQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<GetLocationByIDResponse> Handle(GetLocationByIDRequest request, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.Get(request.ID);
            return _mapper.Map<GetLocationByIDResponse>(locations);
        }
    }
}
