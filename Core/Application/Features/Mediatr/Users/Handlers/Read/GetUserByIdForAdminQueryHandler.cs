using Application.Features.Mediatr.Users.Queries;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces.UserInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Read
{
    public class GetUserByIdForAdminQueryHandler : IRequestHandler<GetUserByIdForAdminQuery, GetUserByIdForAdminQueryResuslt>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdForAdminQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdForAdminQueryResuslt> Handle(GetUserByIdForAdminQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            if(user!=null)
            {
                return new GetUserByIdForAdminQueryResuslt
                {
                    Email = user.Email,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    RoleName = user.Role.RoleName,
                    RoleId=user.Role.RoleId,
                    Surname = user.Surname,
                    UserId = user.UserId
                };
            }
            else
                return null;
            
        }
    }
}
