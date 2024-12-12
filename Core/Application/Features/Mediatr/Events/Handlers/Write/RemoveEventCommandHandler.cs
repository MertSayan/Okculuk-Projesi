using Application.Constants;
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
    public class RemoveEventCommandHandler : IRequestHandler<RemoveEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public RemoveEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Handle(RemoveEventCommand request, CancellationToken cancellationToken)
        {
            var eventt=await _eventRepository.GetEventById(request.Id);
            if (eventt != null)
            {
                await _eventRepository.RemoveEventAsync(eventt);
            }
            else
                throw new Exception(Messages<Event>.EntityNotFound);
        }
    }
}
