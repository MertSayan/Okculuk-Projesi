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
    public class GetUserByMailAndPasswordQueryHandler : IRequestHandler<GetUserByMailAndPasswordQuery, GetUserByMailAndPasswordQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByMailAndPasswordQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByMailAndPasswordQueryResult> Handle(GetUserByMailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user=await _userRepository.GetByFilterAsync(x=>x.Email==request.Email && x.Password==request.Password && x.DeletedDate==null);

            if (user != null)
            {
                return new GetUserByMailAndPasswordQueryResult
                {
                    IsExist = true,
                    UserId = user.UserId,
                    RoleName=user.Role.RoleName,
                };
            }
            else
                return null;
        }
    }
}
