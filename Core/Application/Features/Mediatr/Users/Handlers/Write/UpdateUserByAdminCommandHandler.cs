using Application.Constants;
using Application.Features.Mediatr.Users.Commands;
using Application.Interfaces.UserInterface;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Users.Handlers.Write
{
    public class UpdateUserByAdminCommandHandler : IRequestHandler<UpdateUserByAdminCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserByAdminCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserByAdminCommand request, CancellationToken cancellationToken)
        {
            var user=await _userRepository.GetUserById(request.UserId);
            if (user != null)
            {
                user.RolId = request.RoleId;
                await _userRepository.UpdateUserAsync(user);
            }
            else
                throw new Exception(Messages<User>.EntityNotFound);
            
        }
    }
}
