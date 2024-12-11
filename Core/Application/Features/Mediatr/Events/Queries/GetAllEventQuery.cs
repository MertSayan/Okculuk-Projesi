using Application.Features.Mediatr.Events.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Events.Queries
{
    public class GetAllEventQuery:IRequest<List<GetAllEventQueryResult>>
    {
    }
}
