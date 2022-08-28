using HartleyMedical.Application.AuthModule.Common;
using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.Common.Settings;
using HartleyMedical.Application.ExternalDependencyInterfaces;
using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Domain.Constants;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ResendTwoFACode
{
    public class ResendTwoFACodeHandler : IRequestHandler<ResendTwoFACodeRequest, ResendTwoFACodeResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly TwilioSettings _twilioSettings;
        private readonly ISystemSettingsRepository _systemSettingsRepository;
        private readonly ISMSService _smsService;
        public ResendTwoFACodeHandler(IUserRepository userRepository, IOptions<TwilioSettings> twilioOptions, ISystemSettingsRepository systemSettingsRepository, ISMSService smsService)
        {
            _userRepository = userRepository;
            _twilioSettings = twilioOptions.Value;
            _systemSettingsRepository = systemSettingsRepository;
            _smsService = smsService;
        }
        public Task<ResendTwoFACodeResponse> Handle(ResendTwoFACodeRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByID(request.UserID);
            if (user != null)
            {
                user.SetTwoFACode();
                _userRepository.Complete();
                var systemSettings = _systemSettingsRepository.GetSystemSettings();
                if (_twilioSettings.IsSMSEnabled)
                {
                    _smsService.SendSMS("+" + user.PhoneNumber, $"{user.TwoFACode} is your verification code for Hartley Medical");
                }
                var response = new ResendTwoFACodeResponse
                {
                    UserID = user.ID,
                    Code = user.TwoFACode,
                    ExpiryTime = user.GetTwoFACodeExpiryTime(systemSettings)
                };
                return Task.FromResult(response);
            }
            else
            {
                throw new BadRequestException("User not found");
            }
        }
    }
}
