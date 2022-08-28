using HartleyMedical.Application.AuthModule.Commands.ForgotPassword;
using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.Common.Helpers;
using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Application.ServicesInterfaces;
using HartleyMedical.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ResetPassword
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        public ForgotPasswordRequestHandler(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }
        public async Task<bool> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            bool result;
            var user =await _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                result= false;
            }
            else
            {
                user.PasswordRequestDate = DateTime.UtcNow;
                user.PasswordRequestHash = Guid.NewGuid().ToString();
                _userRepository.Complete();
                _emailService.SendForgotPasswordEmail(user);
                result = true;
            }
            return result;
        }
    }
}