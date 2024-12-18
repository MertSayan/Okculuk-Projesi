using Application.Features.Mediatr.Regions.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Regions.Queries
{
    public class GetAllRegionQuery:IRequest<List<GetAllRegionQueryResult>>
    {
    
    }
}
