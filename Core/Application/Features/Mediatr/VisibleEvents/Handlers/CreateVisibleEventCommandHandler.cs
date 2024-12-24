using Application.Features.Mediatr.VisibleEvents.Commands;
using Application.Interfaces.VisibleEventInterface;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.VisibleEvents.Handlers
{
    public class CreateVisibleEventCommandHandler : IRequestHandler<CreateVisibleEventCommand>
    {
        private readonly IVisibleEventRepository _visibleEventRepository;

        public CreateVisibleEventCommandHandler(IVisibleEventRepository visibleEventRepository)
        {
            _visibleEventRepository = visibleEventRepository;
        }

        public async Task Handle(CreateVisibleEventCommand request, CancellationToken cancellationToken)
        {
            foreach (var eventId in request.EventId)
            {
                foreach (var userId in request.UserId)
                {
                    var visibleEvent = new VisibleEvent
                    {
                        EventId = eventId,
                        UserId = userId,
                    };

                    await _visibleEventRepository.CreateVisibleEvent(visibleEvent);
                }
            }
        }
    }
}
