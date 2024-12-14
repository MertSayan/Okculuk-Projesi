using Application.Features.Mediatr.Events.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Queries
{
    public class GetAllEventByUserIdStatusQuery:IRequest<List<GetAllEventByUserIdStatusQueryResult>>
    {
        public GetAllEventByUserIdStatusQuery(int userId, string status)
        {
            UserId = userId;
            Status = status;
        }

        public int UserId { get; set; }
        public string Status { get; set; }

      
    }
}
