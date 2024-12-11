using Application.Features.Mediatr.Events.Commands;
using Application.Interfaces.EventInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Handlers.Write
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            await _eventRepository.CreateEventAsync(new Event
            {

                Description = request.Description,
                IsActive = request.IsActive,
                DateAndTime = request.DateAndTime,
                Title = request.Title,
                UserId = request.UserId,
            });
        }
    }
}
