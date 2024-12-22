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
    public class CreateEventUserCommandHandler : IRequestHandler<CreateEventUserCommand>
    {
        private readonly IEventUserRepository _eventUserRepository;

        public CreateEventUserCommandHandler(IEventUserRepository eventUserRepository)
        {
            _eventUserRepository = eventUserRepository;
        }

        public async Task Handle(CreateEventUserCommand request, CancellationToken cancellationToken)
        {
            await _eventUserRepository.CreateUserAsync(new EventUser
            {
                BasvuruZamanı=DateTime.Now,
                EventId=request.EventId,
                UserId=request.UserId,
                Status=request.Status,
                RejectedReason=request.RejectedReason,
            });
        }
    }
}
