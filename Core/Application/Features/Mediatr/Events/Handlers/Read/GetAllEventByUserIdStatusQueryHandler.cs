using Application.Features.Mediatr.Events.Queries;
using Application.Features.Mediatr.Events.Results;
using Application.Interfaces.EventInterface;
using MediatR;

namespace Application.Features.Mediatr.Events.Handlers.Read
{
    public class GetAllEventByUserIdStatusQueryHandler : IRequestHandler<GetAllEventByUserIdStatusQuery, List<GetAllEventByUserIdStatusQueryResult>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAllEventByUserIdStatusQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<GetAllEventByUserIdStatusQueryResult>> Handle(GetAllEventByUserIdStatusQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetEventsByStatus(request.UserId, x => x.Status == request.Status);
        }
    }
}
