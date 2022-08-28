using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.Common.Helpers;
using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ResetPassword
{
    public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISystemSettingsRepository _systemSettingsRepository;
        public ResetPasswordRequestHandler(IUserRepository userRepository, ISystemSettingsRepository systemSettingsRepository)
        {
            _userRepository = userRepository;
            _systemSettingsRepository = systemSettingsRepository;
        }
        public Task<bool> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            bool result = false;
            var systemSettings = _systemSettingsRepository.GetSystemSettings();
            var urlExpirySettings = systemSettings.Where(c => c.SettingName == SystemSettingsVariables.URLExpiryTime).FirstOrDefault();
            var user = _userRepository.GetFirst(c => c.PasswordRequestHash == request.Code && !c.IsDeleted);
            if (user == null)
            {
                throw new BadRequestException("Token not found");
            }
            else if (user != null && DateTime.UtcNow.Subtract(user.PasswordRequestDate.Value).TotalMinutes >= Convert.ToInt32(urlExpirySettings.SettingValue))
            {
                throw new BadRequestException("Token expired");
            }
            else
            {
                user.Password = request.Password.WithBCrypt();
                user.PasswordRequestHash = null;
                _userRepository.Complete();
                result = true;
            }
            return Task.FromResult(result);
        }
    }
}