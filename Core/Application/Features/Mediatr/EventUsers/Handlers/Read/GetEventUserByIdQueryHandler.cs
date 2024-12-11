using Application.Features.Mediatr.EventUsers.Queries;
using Application.Features.Mediatr.EventUsers.Results;
using Application.Interfaces.EventUserInterface;
using MediatR;

namespace Application.Features.Mediatr.EventUsers.Handlers.Read
{
    public class GetEventUserByIdQueryHandler : IRequestHandler<GetEventUserByIdQuery, GetEventUserByIdQueryResult>
    {
        private readonly IEventUserRepository _eventUserRepository;

        public GetEventUserByIdQueryHandler(IEventUserRepository eventUserRepository)
        {
            _eventUserRepository = eventUserRepository;
        }

        public async Task<GetEventUserByIdQueryResult> Handle(GetEventUserByIdQuery request, CancellationToken cancellationToken)
        {
            var eventUser=await _eventUserRepository.GetEventUserById(request.Id);
            if (eventUser != null)
            {
                return new GetEventUserByIdQueryResult
                {
                    BasvuruZamanı=eventUser.BasvuruZamanı,
                    EventTitle=eventUser.Event.Title,
                    UserName=eventUser.User.Name+" "+eventUser.User.Surname,
                    EventUserId=eventUser.UserId,
                    Status=eventUser.Status,
                };
            }
            return null;
        }
    }
}
