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
    public class GetPagedEventQueryHandler : IRequestHandler<GetPagedEventQuery, List<GetPagedEventQueryResult>>
    {
        private readonly IEventRepository _eventRepository;

        public GetPagedEventQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<GetPagedEventQueryResult>> Handle(GetPagedEventQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetPagedEventAsync(request.PageNumber,request.PageSize);
            return events.Select(x=> new GetPagedEventQueryResult
            {
                DateAndTime = x.DateAndTime,
                Description = x.Description,
                EventId = x.EventId,
                IsActive = x.IsActive,
                Title = x.Title,
                UserName=x.User.Name+" "+x.User.Surname
            }).ToList();
        }
    }
}
