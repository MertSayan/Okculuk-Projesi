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
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventt = await _eventRepository.GetEventById(request.EventId);
            if(eventt != null)
            {
                eventt.Title = request.Title;
                eventt.Description = request.Description;
                eventt.DateAndTime = request.DateAndTime;
                eventt.Description=request.Description;
                eventt.IsActive = request.IsActive;

                await _eventRepository.UpdateEventAsync(eventt);
            }
            else
                throw new Exception(Messages<Event>.EntityNotFound);
        }
    }
}
