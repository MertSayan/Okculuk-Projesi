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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user=await _userRepository.GetUserById(request.UserId);
            if (user != null)
            {
                user.Surname = request.Surname;
                user.Name= request.Name;
                user.PhoneNumber= request.PhoneNumber;
                user.Email= request.Email;
                user.Password= request.Password;
                await _userRepository.UpdateUserAsync(user);
            }
            else if (user.DeletedDate != null)
            {
                throw new Exception(Messages<User>.EntityAlreadyDeleted);
            }
            throw new Exception(Messages<User>.EntityNotFound);
        }
    }
}
