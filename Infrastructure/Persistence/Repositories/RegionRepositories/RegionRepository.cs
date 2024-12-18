using Application.Interfaces.RegionInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.RegionRepositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly OkculukContext _context;

        public RegionRepository(OkculukContext context)
        {
            _context = context;
        }

        public async Task<List<Region>> GetAllRegion()
        {
            return await _context.Regions
                .ToListAsync();
        }
    }
}
