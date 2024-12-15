using Application.Features.Mediatr.Events.Queries;
using Application.Features.Mediatr.Events.Results;
using Application.Interfaces.EventInterface;
using MediatR;

namespace Application.Features.Mediatr.Events.Handlers.Read
{
    public class GetEventsCountByStatusAndUserIdQueryHandler : IRequestHandler<GetEventsCountByStatusAndUserIdQuery, GetEventsCountByStatusAndUserIdQueryResult>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsCountByStatusAndUserIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<GetEventsCountByStatusAndUserIdQueryResult> Handle(GetEventsCountByStatusAndUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetEventsCountByStatusByUserId(request.UserId);
        }
    }
}
