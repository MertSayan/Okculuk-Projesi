using Application.Features.Mediatr.Events.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Queries
{
    public class GetAllEventByUserIdQuery:IRequest<List<GetAllEventByUserIdQueryResult>>
    {
        public int UserId { get; set; }

        public GetAllEventByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
