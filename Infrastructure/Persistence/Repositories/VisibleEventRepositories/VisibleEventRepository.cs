using Application.Interfaces.VisibleEventInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.VisibleEventRepositories
{
    public class VisibleEventRepository : IVisibleEventRepository
    {
        private readonly OkculukContext _context;

        public VisibleEventRepository(OkculukContext context)
        {
            _context = context;
        }

        public async Task CreateVisibleEvent(VisibleEvent visibleEvent)
        {
            _context.VisibleEvents.Add(visibleEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VisibleEvent>> GetAllVisibleEvent()
        {
            return await _context.VisibleEvents
                .Include(x=>x.Events)
                .Include(x=>x.Users)
                .ToListAsync();
        }
    }
}
