using Application.Features.Mediatr.Events.Results;
using MediatR;

namespace Application.Features.Mediatr.Events.Queries
{
    public class GetEventByIdQuery:IRequest<GetEventByIdQueryResult>
    {
        public int Id { get; set; }

        public GetEventByIdQuery(int id)
        {
            Id = id;
        }
    }
}
