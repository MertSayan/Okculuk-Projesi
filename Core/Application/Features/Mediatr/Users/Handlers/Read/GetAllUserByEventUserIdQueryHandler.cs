using Application.Constants;
using Application.Features.Mediatr.Users.Queries;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces.EventInterface;
using Application.Interfaces.UserInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Handlers.Read
{
    public class GetAllUserByEventUserIdQueryHandler : IRequestHandler<GetAllUserByEventUserIdQuery, List<GetAllUserByEventUserIdQueryResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;

        public GetAllUserByEventUserIdQueryHandler(IUserRepository userRepository, IEventRepository eventRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public async Task<List<GetAllUserByEventUserIdQueryResult>> Handle(GetAllUserByEventUserIdQuery request, CancellationToken cancellationToken)
        {
            var eventt=await _eventRepository.GetEventById(request.EventId);
            if (eventt != null)
            {
                return await _userRepository.GetAllUserByEventUserId(request.EventId);
            }
            else
                throw new Exception(Messages<Event>.EntityNotFound);
        }
    }
}
