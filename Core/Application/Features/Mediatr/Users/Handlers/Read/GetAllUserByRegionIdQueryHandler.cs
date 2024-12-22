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
    public class GetAllUserByRegionIdQueryHandler : IRequestHandler<GetAllUserByRegionIdQuery, List<GetAllUserByRegionIdQueryResult>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserByRegionIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetAllUserByRegionIdQueryResult>> Handle(GetAllUserByRegionIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUserByRegionId(request.RegionName);
            return users.Select(x=> new GetAllUserByRegionIdQueryResult
            {
                UserId=x.UserId,
                Name = x.Name,
                Surname = x.Surname,
                RegionName=x.Region.RegionName
            }).ToList();
        }
    }
}
