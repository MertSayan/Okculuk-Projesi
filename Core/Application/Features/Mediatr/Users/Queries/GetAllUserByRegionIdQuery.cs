using Application.Features.Mediatr.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Users.Queries
{
    public class GetAllUserByRegionIdQuery:IRequest<List<GetAllUserByRegionIdQueryResult>>
    {
        public string RegionName { get; set; }

        public GetAllUserByRegionIdQuery(string regionName)
        {
            RegionName = regionName;
        }
    }
}
