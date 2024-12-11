using Application.Features.Mediatr.Events.Queries;
using Application.Features.Mediatr.Events.Results;
using Application.Interfaces.EventInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Handlers.Read
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, GetEventByIdQueryResult>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<GetEventByIdQueryResult> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventt=await _eventRepository.GetEventById(request.Id);
            if(eventt!=null)
            {
                return new GetEventByIdQueryResult
                {

                    Description = eventt.Description,
                    EventId = eventt.EventId,
                    IsActive = eventt.IsActive,
                    DateAndTime=eventt.DateAndTime,
                    Title = eventt.Title,
                    UserName = eventt.User.Name+" "+eventt.User.Surname
                };
            }
            return null;
        }
    }
}
