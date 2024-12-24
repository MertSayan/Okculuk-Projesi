using Application.Features.Mediatr.Events.Queries;
using Application.Features.Mediatr.Events.Results;
using Application.Interfaces.EventInterface;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Handlers.Read
{
    public class GetEventsCountByStatusAndEventIdQueryHandler : IRequestHandler<GetEventsCountByStatusAndEventIdQuery, GetEventsCountByStatusAndEventIdQueryResult>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsCountByStatusAndEventIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<GetEventsCountByStatusAndEventIdQueryResult> Handle(GetEventsCountByStatusAndEventIdQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetEventsCountByStatusAndEventId(request.EventId);
        }
    }
}
