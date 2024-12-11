using Application.Features.Mediatr.EventUsers.Results;
using MediatR;

namespace Application.Features.Mediatr.EventUsers.Queries
{
    public class GetEventUserByIdQuery:IRequest<GetEventUserByIdQueryResult>
    {
        public int Id { get; set; }

        public GetEventUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
