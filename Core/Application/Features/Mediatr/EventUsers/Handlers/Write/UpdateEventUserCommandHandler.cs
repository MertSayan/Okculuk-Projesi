using Application.Constants;
using Application.Features.Mediatr.EventUsers.Commands;
using Application.Interfaces.EventUserInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.EventUsers.Handlers.Write
{
    public class UpdateEventUserCommandHandler : IRequestHandler<UpdateEventUserCommand>
    {
        private readonly IEventUserRepository _eventUserRepository;

        public UpdateEventUserCommandHandler(IEventUserRepository eventUserRepository)
        {
            _eventUserRepository = eventUserRepository;
        }

        public async Task Handle(UpdateEventUserCommand request, CancellationToken cancellationToken)
        {
            var eventUser = await _eventUserRepository.GetEventUserById(request.EventUserId);
            if (eventUser!=null)
            {
                eventUser.Status=request.Status;
                await _eventUserRepository.UpdateUserAsync(eventUser);
            }
            else
                throw new Exception(Messages<Event>.EntityNotFound);
        }
    }
}
