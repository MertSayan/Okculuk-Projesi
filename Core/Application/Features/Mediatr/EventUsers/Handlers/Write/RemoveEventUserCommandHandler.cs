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
    public class RemoveEventUserCommandHandler : IRequestHandler<RemoveEventUserCommand>
    {
        private readonly IEventUserRepository _eventUserRepository;

        public RemoveEventUserCommandHandler(IEventUserRepository eventUserRepository)
        {
            _eventUserRepository = eventUserRepository;
        }

        public async Task Handle(RemoveEventUserCommand request, CancellationToken cancellationToken)
        {
            var eventUser=await _eventUserRepository.GetEventUserById(request.Id);
            if (eventUser != null)
            {
                await _eventUserRepository.RemoveUserAsync(eventUser);
            }
            else
                throw new Exception(Messages<EventUser>.EntityNotFound);
        }
    }
}
