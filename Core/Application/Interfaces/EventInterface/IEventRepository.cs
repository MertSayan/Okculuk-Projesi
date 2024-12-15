using Application.Features.Mediatr.Events.Results;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.EventInterface
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEventAsync();
        Task<Event> GetEventById(int id);
        Task CreateEventAsync(Event eventt);
        Task RemoveEventAsync(Event eventt);
        Task UpdateEventAsync(Event eventt);

        Task<List<GetAllEventByUserIdQueryResult>> GetAllEventByUserId(int userId);

        Task<List<Event>> GetAvailableEventsForUserAsync(int userId);

        Task<List<GetAllEventByUserIdStatusQueryResult>> GetEventsByStatus(int userId, Expression<Func<EventUser, bool>> statusPredicate);

        Task<GetEventsCountByStatusAndUserIdQueryResult> GetEventsCountByStatusByUserId(int userId);

        Task<List<GetAllPendingEventQueryResult>> GetAllPendingEvent();


    }
}
