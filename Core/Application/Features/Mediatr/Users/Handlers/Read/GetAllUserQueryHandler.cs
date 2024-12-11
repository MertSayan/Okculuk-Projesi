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
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<GetAllUserQueryResult>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetAllUserQueryResult>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUserAsync();
            return users.Select(x=> new GetAllUserQueryResult
            {
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                RoleName=x.Role.RoleName,
                Surname=x.Surname,
                UserId=x.UserId, 
                Email=x.Email,
            }).ToList();
        }
    }
}
