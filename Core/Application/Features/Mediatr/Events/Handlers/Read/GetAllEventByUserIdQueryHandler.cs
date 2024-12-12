using Application.Constants;
using Application.Features.Mediatr.Events.Queries;
using Application.Features.Mediatr.Events.Results;
using Application.Interfaces.EventInterface;
using Application.Interfaces.UserInterface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Handlers.Read
{
    public class GetAllEventByUserIdQueryHandler : IRequestHandler<GetAllEventByUserIdQuery, List<GetAllEventByUserIdQueryResult>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;

        public GetAllEventByUserIdQueryHandler(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        public async Task<List<GetAllEventByUserIdQueryResult>> Handle(GetAllEventByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user=await _userRepository.GetUserById(request.UserId);
            if (user != null)
            {
                var events = await _eventRepository.GetAllEventByUserId(request.UserId);
                return events.Select(x => new GetAllEventByUserIdQueryResult
                {
                    DateAndTime = x.DateAndTime,
                    Description = x.Description,
                    EventId = x.EventId,
                    IsActive = x.IsActive,
                    Title = x.Title,
                }).ToList();
            }
            else
                throw new Exception(Messages<User>.EntityNotFound);
        }
    }
}
