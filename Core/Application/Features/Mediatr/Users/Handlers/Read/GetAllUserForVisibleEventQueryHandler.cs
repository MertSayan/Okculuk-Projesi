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
    public class GetAllUserForVisibleEventQueryHandler : IRequestHandler<GetAllUserForVisibleEventQuery, List<GetAllUserForVisibleEventQueryResult>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserForVisibleEventQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetAllUserForVisibleEventQueryResult>> Handle(GetAllUserForVisibleEventQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUserAsync();
            return users.Select(x => new GetAllUserForVisibleEventQueryResult
            {
                Name = x.Name,
               Surname=x.Surname,
               RegionName=x.Region.RegionName,
               UserId=x.UserId
            }).ToList();
        }
    }
}
