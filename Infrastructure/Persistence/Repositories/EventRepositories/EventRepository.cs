using Application.Constants;
using Application.Features.Mediatr.Events.Results;
using Application.Interfaces.EventInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Event>> GetPagedEventAsync(int pageNumber, int pageSize)
        {
            return await _context.Events
                .Where(x => x.DeletedDate == null)
                .Include(x => x.User)
                .OrderByDescending(x => x.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<GetAllEventByUserIdQueryResult>> GetAllEventByUserId(int userId)
        {

            return await _context.EventsAndUsers
                .Where(x => x.DeletedDate == null && x.UserId == userId)
                .Include(x => x.Event)
                .Select(x => new GetAllEventByUserIdQueryResult
                {
                   Title=x.Event.Title,
                   Description=x.Event.Description,
                   DateAndTime=x.Event.DateAndTime,
                   EventId=x.Event.EventId,
                   IsActive=x.Event.IsActive,
                   Status = x.Status,
                   RejectedReason=x.RejectedReason
                })
                .ToListAsync();
        }

        public async Task<List<GetAllPendingEventQueryResult>> GetAllPendingEvent()
        {
            return await _context.EventsAndUsers
                .Where(x => x.DeletedDate == null && x.Status == "Pending")
                .Include(x => x.Event)
                .Include(x => x.User)
                .Select(x=> new GetAllPendingEventQueryResult
                {
                    Status=x.Status,
                    Description=x.Event.Description,
                    EventUserId=x.EventUserId,
                    PhoneNumber=x.User.PhoneNumber,
                    Title=x.Event.Title,
                    UserName=x.User.Name+" "+x.User.Surname,
                    UserId=x.User.UserId,
                }).ToListAsync();
        }

        public async Task<List<Event>> GetAvailableEventsForUserAsync(int userId)
        {
            // Kullanıcının daha önce katılma/kabul/red durumlarına göre filtreleme
            var userEventIdsForUserEvent = await _context.EventsAndUsers
                .Where(eu => eu.DeletedDate == null && eu.UserId == userId)
                .Select(eu => eu.EventId)
                .ToListAsync();

            var userEventIds = await _context.VisibleEvents
                .Where(x => x.UserId == userId)
                .Select(x => x.EventId)
                .ToListAsync();

            return await _context.Events
                .Where(x => x.DeletedDate == null && userEventIds.Contains(x.EventId) && !userEventIdsForUserEvent.Contains(x.EventId))
                .Include(x => x.User)
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

        public async Task<List<GetAllEventByUserIdStatusQueryResult>> GetEventsByStatus(int userId, Expression<Func<EventUser, bool>> statusPredicate)
        {
            return await _context.EventsAndUsers
                .Where(x => x.DeletedDate == null && x.UserId == userId)
                .Where(statusPredicate) // Dinamik filtreleme
                .Include(x => x.Event)  // Etkinlik detaylarını dahil et
                .Select(x => new GetAllEventByUserIdStatusQueryResult
                {
                    Title = x.Event.Title,
                    Description = x.Event.Description,
                    DateAndTime = x.Event.DateAndTime,
                    EventId = x.Event.EventId,
                    IsActive = x.Event.IsActive,
                    UserName=x.User.Name+" "+x.User.Surname,
                })
                .ToListAsync();
        }

        public async Task<GetEventsCountByStatusAndUserIdQueryResult> GetEventsCountByStatusByUserId(int userId)
        {
           
            var acceptedCount = await _context.EventsAndUsers
                .Where(eu => eu.UserId == userId && eu.Status == "Accepted")
                .CountAsync();

            var rejectedCount = await _context.EventsAndUsers
                .Where(eu => eu.UserId == userId && eu.Status == "Rejected")
                .CountAsync();

            var pendingCount = await _context.EventsAndUsers
                .Where(eu => eu.UserId == userId && eu.Status == "Pending")
                .CountAsync();

            return new GetEventsCountByStatusAndUserIdQueryResult
            {
                AcceptedCount = acceptedCount,
                RejectedCount = rejectedCount,
                PendingCount=pendingCount 
            };
        }

        public async Task<GetEventsCountByStatusAndEventIdQueryResult> GetEventsCountByStatusAndEventId(int eventId)
        {
            var acceptedCount = await _context.EventsAndUsers
                .Where(eu => eu.EventId == eventId && eu.Status == "Accepted")
                .CountAsync();

            var rejectedCount = await _context.EventsAndUsers
                .Where(eu => eu.EventId == eventId && eu.Status == "Rejected")
                .CountAsync();

            var pendingCount = await _context.EventsAndUsers
                .Where(eu => eu.EventId == eventId && eu.Status == "Pending")
                .CountAsync();

            return new GetEventsCountByStatusAndEventIdQueryResult
            {
                AcceptedCount = acceptedCount,
                RejectedCount = rejectedCount,
                PendingCount = pendingCount
            };
        }


        public async Task RemoveEventAsync(Event eventt)
        {
            if(eventt.DeletedDate == null)
            {
                eventt.DeletedDate= DateTime.Now;

                var relatedEventUsers=_context.EventsAndUsers.Where(x=>x.EventId == eventt.EventId && x.DeletedDate==null).ToList();
                foreach (var item in relatedEventUsers)
                {
                    item.DeletedDate = DateTime.Now;
                }

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
