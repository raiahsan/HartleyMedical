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

namespace HartleyMedical.Application.AuthModule.Commands.ValidateResetPasswordLink
{
    public class ValidateResetPasswordLinkHandler : IRequestHandler<ValidateResetPasswordLinkRequest, ValidateResetPasswordLinkResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISystemSettingsRepository _systemSettingsRepository;
        private readonly ISMSService _smsService;
        private readonly TwilioSettings _twilioSettings;
        public ValidateResetPasswordLinkHandler(
            IUserRepository userRepository, 
            ISystemSettingsRepository systemSettingsRepository,
            ISMSService smsService,
            IOptions<AppSettings> appSettings,
            IOptions<TwilioSettings> twilioSettings)
        {
            _userRepository = userRepository;
            _systemSettingsRepository = systemSettingsRepository;
            _smsService = smsService;
            _twilioSettings = twilioSettings.Value;
        }
        public Task<ValidateResetPasswordLinkResponse> Handle(ValidateResetPasswordLinkRequest request, CancellationToken cancellationToken)
        {
            ValidateResetPasswordLinkResponse validateResetPasswordLinkResponse = null;
            var systemSettings = _systemSettingsRepository.GetSystemSettings();
            var urlExpirySettings = systemSettings.Where(c => c.SettingName == SystemSettingsVariables.URLExpiryTime).FirstOrDefault();
            var user = _userRepository.GetFirst(c => c.PasswordRequestHash == request.Code && !c.IsDeleted);
            if (user == null)
            {
                throw new BadRequestException("Token not found");
            }
            //else if (user != null && DateTime.UtcNow.Subtract(user.PasswordRequestDate.Value).TotalMinutes >= Convert.ToInt32(urlExpirySettings.SettingValue))
            //{
            //    throw new BadRequestException("Token expired");
            //}
            else
            {
                user.SetTwoFACode();
                _userRepository.Complete();
                validateResetPasswordLinkResponse = new ()
                {
                    UserID = user.ID,
                    Email = user.Email,
                    Code = user.TwoFACode,
                    ExpiryTime = user.GetTwoFACodeExpiryTime(systemSettings)
                };

                if (_twilioSettings.IsSMSEnabled)
                {
                    _smsService.SendSMS("+" + user.PhoneNumber, $"{user.TwoFACode} is your verification code for Hartley Medical");
                }
            }
            return Task.FromResult(validateResetPasswordLinkResponse);
        }
    }
}
