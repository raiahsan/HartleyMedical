using AutoMapper;
using HartleyMedical.Application.AuthModule.Common;
using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.Common.Settings;
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
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ValidateTwoFACode
{
    public class ValidateTwoFACodeHandler : IRequestHandler<ValidateTwoFACodeRequest, Object>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly ISystemSettingsRepository _systemSettingsRepository;
        public ValidateTwoFACodeHandler(IUserRepository userRepository, IRoleRepository roleRepository, IOptions<AppSettings> appSettingsOption, IMapper mapper, ISystemSettingsRepository systemSettingsRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _appSettings = appSettingsOption.Value;
            _mapper = mapper;
            _systemSettingsRepository = systemSettingsRepository;
        }
        public Task<Object> Handle(ValidateTwoFACodeRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByID(request.UserID);
            var systemSettings = _systemSettingsRepository.GetSystemSettings();
            var tokenValiditySettings = systemSettings.Where(c => c.SettingName == SystemSettingsVariables.TwoFACodeExpiryTime).FirstOrDefault();
            if (user != null)
            {
                if (user.TwoFACode != request.Code)
                {
                    throw new BadRequestException($"Invalid code");
                }
                else if (DateTime.UtcNow.Subtract(user.TwoFACodeRequestDate.Value).TotalMinutes >= Convert.ToInt32(tokenValiditySettings?.SettingValue ?? "5"))
                {
                    throw new BadRequestException($"Code expired");
                }
                else
                {
                    user.TwoFACode = null;
                    _userRepository.Complete();
                    if (request.IsLoginRequest)
                    {
                        var userDto = new UserDto();
                        if (user.fk_UserTypeID == 3)// Will Change 3 with Enum
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
                    else
                    {
                        return Task.FromResult<Object>(true);
                    }
                }
            }
            else
            {
                throw new BadRequestException($"User with ID '{request.UserID}' not found");
            }

        }
    }
}
