using Application.Constants;
using Application.Features.Mediatr.Users.Commands;
using Application.Interfaces.UserInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Write
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user=await _userRepository.GetUserById(request.Id);
            if (user != null)
            {
                await _userRepository.RemoveUserAsync(user);
            }
            throw new Exception(Messages<User>.EntityNotFound);
        }
    }
}
