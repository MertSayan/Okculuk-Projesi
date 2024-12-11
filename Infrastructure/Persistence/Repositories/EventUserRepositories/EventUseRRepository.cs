using Application.Constants;
using Application.Interfaces.EventUserInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.EventUserRepositories
{
    public class EventUseRRepository : IEventUserRepository
    {
        private readonly OkculukContext _context;

        public EventUseRRepository(OkculukContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(EventUser eventUser)
        {
            eventUser.CreatedDate= DateTime.Now;    
            _context.EventsAndUsers.Add(eventUser);
            await _context.SaveChangesAsync();
        }

        public Task<List<EventUser>> GetAllEventUserAsync()
        {
            return _context.EventsAndUsers
                .Where(x=>x.DeletedDate==null)
                .Include(x=>x.User)
                .Include(x=>x.Event)
                .ToListAsync();
        }

        public async Task<EventUser> GetEventUserById(int id)
        {
            var eventt = await _context.EventsAndUsers
                .Where(x => x.DeletedDate == null)
                .Include(x => x.User)
                .Include(x => x.Event)
                .FirstOrDefaultAsync(x => x.EventUserId == id);
            if(eventt != null)
            {
                return eventt;
            }
            return null;
        }

        public async Task RemoveUserAsync(EventUser eventUser)
        {
            if (eventUser.DeletedDate == null)
            {
                eventUser.DeletedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(Messages<EventUser>.EntityAlreadyDeleted);
            }
            
        }

        public async Task UpdateUserAsync(EventUser eventUser)
        {
            eventUser.UpdatedDate=DateTime.Now;
            _context.Update(eventUser);
            await _context.SaveChangesAsync();
        }
    }
}
