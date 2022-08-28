using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Commands.DeleteUser
{
    public class DeleteUserByIDCommandHandler : IRequestHandler<DeleteUserByIDRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserByIDCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> Handle(DeleteUserByIDRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = false;
                User user = _userRepository.GetFirst(c => c.ID == request.ID && !c.IsDeleted);
                if (user != null)
                {
                    user.IsDeleted = true;
                    _userRepository.Complete();
                    result = true;
                }
                else
                {
                    throw new BadRequestException($"User '{request.ID}' not found");
                }
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
