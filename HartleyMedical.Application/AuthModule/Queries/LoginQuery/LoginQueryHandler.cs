using AutoMapper;
using HartleyMedical.Application.AuthModule.Common;
using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.Common.Settings;
using HartleyMedical.Application.ExternalDependencyInterfaces;
using HartleyMedical.Application.RepositoryInterfaces;
using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Application.RoleModule.Models;
using HartleyMedical.Application.UserModule.Models;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID;
using HartleyMedical.Domain.Constants;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Queries.LoginQuery
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, Object>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISMSService _smsService;
        private readonly TwilioSettings _twilioSettings;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly ISystemSettingsRepository _systemSettingsRepository;
        private readonly IRoleRepository _roleRepository;

        public LoginQueryHandler(IUserRepository userRepository, IRoleRepository roleRepository, ISMSService smsService, IOptions<TwilioSettings> twilioSettings, ISystemSettingsRepository systemSettingsRepository, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _smsService = smsService;
            _twilioSettings = twilioSettings.Value;
            _systemSettingsRepository = systemSettingsRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public Task<Object> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Authenticate(request.Email, request.Password).Result;
            if (user != null)
            {
                if (user.TwoFAEnabled)
                {
                    user.SetTwoFACode();
                    _userRepository.Complete();
                    var systemSettings = _systemSettingsRepository.GetSystemSettings();
                    if (_twilioSettings.IsSMSEnabled)
                    {
                        _smsService.SendSMS("+" + user.PhoneNumber, $"{user.TwoFACode} is your verification code for Hartley Medical");
                    }
                    var loginQueryResponse = new LoginQueryResponse
                    {
                        UserID = user.ID,
                        Code = user.TwoFACode,
                        PhoneNumber = user.PhoneNumber,
                        ExpiryTime = user.GetTwoFACodeExpiryTime(systemSettings)
                    };
                    return Task.FromResult<Object>(loginQueryResponse);
                }
                else
                {
                    var userDto = new UserDto();
                    if (user.fk_UserTypeID == 3)// Will update 3 with Enum
                    {
                        userDto = _mapper.Map<UserDto>(user);
                    }
                    else
                    {
                        var userDetail = _userRepository.GetUserDetailsByID(new GetUserDetailsByIDRequest { UserID = user.ID });
                        if (userDetail.UserToOrganizationDetails != null)
                        {

                            userDto = _mapper.Map<UserDto>(userDetail);
                            int count = 1;
                            foreach (var org in userDto.UserToOrganizationDetails)
                            {
                                if (count == 1)
                                {
                                    org.IsCurrent = true;
                                }
                                org.ModuleToActions = _roleRepository.GetPermissionsByRoleID(org.RoleID, true)
                                    .Select(c => new ModuleToActionsDto
                                    {
                                        Action = c.ActionName,
                                        Subject = c.ModuleName,
                                    }).ToList();
                                count++;
                            }
                        }

                    }



                    return Task.FromResult<Object>(userDto.GetAuthToken(_appSettings));
                }
            }
            else
            {
                throw new BadRequestException("Invalid credentials");
            }
        }
    }
}
