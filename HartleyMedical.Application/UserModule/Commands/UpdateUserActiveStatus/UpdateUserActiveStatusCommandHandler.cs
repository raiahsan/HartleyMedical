using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Commands.UpdateUserActiveStatus
{
    public class UpdateUserActiveStatusCommandHandler : IRequestHandler<UpdateUserActiveStatusRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserActiveStatusCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(UpdateUserActiveStatusRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = false;
                User user = await _userRepository.Get(request.ID);
                if (user != null)
                {
                    user.Active = request.Active;
                    _userRepository.Complete();
                    result = true;
                }
                else
                {
                    throw new BadRequestException($"User with ID '{request.ID}' not found");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
