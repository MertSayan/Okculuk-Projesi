using Application.Features.Mediatr.EventUsers.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.EventUsers.Queries
{
    public class GetAllEventUserQuery:IRequest<List<GetAllEventUserQueryResult>>
    {
    }
}
