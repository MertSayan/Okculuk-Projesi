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
    public class GetAllPendingEventQueryHandler : IRequestHandler<GetAllPendingEventQuery, List<GetAllPendingEventQueryResult>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAllPendingEventQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<GetAllPendingEventQueryResult>> Handle(GetAllPendingEventQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetAllPendingEvent();
        }
    }
}
