using Application.Features.Mediatr.Regions.Queries;
using Application.Features.Mediatr.Regions.Results;
using Application.Interfaces.RegionInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Regions.Handlers.Read
{
    public class GetAllRegionQueryHandler : IRequestHandler<GetAllRegionQuery, List<GetAllRegionQueryResult>>
    {
        private readonly IRegionRepository _regionRepository;

        public GetAllRegionQueryHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<List<GetAllRegionQueryResult>> Handle(GetAllRegionQuery request, CancellationToken cancellationToken)
        {
            var region = await _regionRepository.GetAllRegion();
            return region.Select(x=>new GetAllRegionQueryResult
            {
                RegionId = x.RegionId,
                RegionName = x.RegionName,
            }).ToList();
        }
    }
}
