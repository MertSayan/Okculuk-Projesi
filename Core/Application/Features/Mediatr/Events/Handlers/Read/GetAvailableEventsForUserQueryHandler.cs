using Application.Features.Mediatr.Events.Queries;
using Application.Features.Mediatr.Events.Results;
using Application.Interfaces.EventInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Handlers.Read
{
    public class GetAvailableEventsForUserQueryHandler : IRequestHandler<GetAvailableEventsForUserQuery, List<GetAvailableEventsForUserQueryResult>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAvailableEventsForUserQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<GetAvailableEventsForUserQueryResult>> Handle(GetAvailableEventsForUserQuery request, CancellationToken cancellationToken)
        {
            var availableEvents = await _eventRepository.GetAvailableEventsForUserAsync(request.UserId);
            if (availableEvents != null)
            {
                return availableEvents.Select(x=> new GetAvailableEventsForUserQueryResult
                {
                    DateAndTime = x.DateAndTime,
                    Description = x.Description,
                    EventId = x.EventId,
                    IsActive = x.IsActive,
                    Title = x.Title,
                    UserName=x.User.Name+" "+x.User.Surname,
                }).ToList();
            }
            return null;
        }
    }
}
