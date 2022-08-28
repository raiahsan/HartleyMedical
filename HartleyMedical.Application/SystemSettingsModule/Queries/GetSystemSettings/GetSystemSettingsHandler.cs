using AutoMapper;
using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.SystemSettingsModule.Queries.GetSystemSettings
{
    public class GetSystemSettingsHandler : IRequestHandler<GetSystemSettingsRequest, List<GetSystemSettingsResponse>>
    {
        private ISystemSettingsRepository _systemSettingsRepository;
        private readonly IMapper _mapper;
        public GetSystemSettingsHandler(ISystemSettingsRepository systemSettingsRepository, IMapper mapper)
        {
            _systemSettingsRepository = systemSettingsRepository;
            _mapper = mapper;
        }
        public Task<List<GetSystemSettingsResponse>> Handle(GetSystemSettingsRequest request, CancellationToken cancellationToken)
        {
            var systemSettings = _systemSettingsRepository.GetSystemSettings();
            return Task.FromResult(_mapper.Map<List<SystemSetting>, List<GetSystemSettingsResponse>>(systemSettings));


        }
    }
}
