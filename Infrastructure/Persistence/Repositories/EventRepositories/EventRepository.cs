using Application.Constants;
using Application.Interfaces.EventInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.EventRepositories
{
    public class EventRepository : IEventRepository
    {
        private readonly OkculukContext _context;

        public EventRepository(OkculukContext context)
        {
            _context = context;
        }
        public async Task CreateEventAsync(Event eventt)
        {
            eventt.CreatedDate = DateTime.Now;
            _context.Events.Add(eventt);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Event>> GetAllEventAsync()
        {
            return await _context.Events
                .Where(x => x.DeletedDate == null)
                .Include(x => x.User)
                .ToListAsync();

        }

        public async Task<List<Event>> GetAllEventByUserId(int userId)
        {
            return await _context.EventsAndUsers
                .Where(x => x.DeletedDate == null && x.UserId == userId)
                .Include(x => x.Event)
                .Select(x => x.Event)
                .ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            var eventt=await _context.Events
                .Where(x=>x.DeletedDate==null)
                .Include(x=>x.User)
                .FirstOrDefaultAsync(x=>x.EventId==id);
            if (eventt != null)
            {
                return eventt;
            }
            return null;
        }

        public async Task RemoveEventAsync(Event eventt)
        {
            if(eventt.DeletedDate == null)
            {
                eventt.DeletedDate= DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(Messages<Event>.EntityAlreadyDeleted);
            }
        }

        public async Task UpdateEventAsync(Event eventt)
        {
            eventt.UpdatedDate= DateTime.Now;
            _context.Update(eventt);
            await _context.SaveChangesAsync();
        }
    }
}
