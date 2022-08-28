using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.RepositoryInterfaces.IStateRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.GeneralModule.Queries.GetAllStates
{
    public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesRequest, List<LookupDto>>
    {
        private readonly IStateRepository _stateRepository;
        public GetAllStatesQueryHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public Task<List<LookupDto>> Handle(GetAllStatesRequest request, CancellationToken cancellationToken)
        {
            var states = _stateRepository.GetMany(c => c.Active)
                .Select(c => new LookupDto
                {
                    Key = c.ID,
                    Value = c.Name
                }).ToList();
            return Task.FromResult(states);
        }
    }
}
