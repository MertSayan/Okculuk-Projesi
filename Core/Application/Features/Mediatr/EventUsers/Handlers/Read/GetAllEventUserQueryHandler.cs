using Application.Features.Mediatr.EventUsers.Queries;
using Application.Features.Mediatr.EventUsers.Results;
using Application.Interfaces.EventUserInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.EventUsers.Handlers.Read
{
    public class GetAllEventUserQueryHandler : IRequestHandler<GetAllEventUserQuery, List<GetAllEventUserQueryResult>>
    {
        private readonly IEventUserRepository _eventUserRepository;

        public GetAllEventUserQueryHandler(IEventUserRepository eventUserRepository)
        {
            _eventUserRepository = eventUserRepository;
        }

        public async Task<List<GetAllEventUserQueryResult>> Handle(GetAllEventUserQuery request, CancellationToken cancellationToken)
        {
            var eventUsers = await _eventUserRepository.GetAllEventUserAsync();
            return eventUsers.Select(x=> new GetAllEventUserQueryResult
            {
                BasvuruZamanı=x.BasvuruZamanı,
                EventTitle=x.Event.Title,
                EventUserId=x.EventUserId,
                Status=x.Status,
                UserName=x.User.Name+" "+x.User.Surname,
            }).ToList();
        }
    }
}
