using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.EventUserInterface
{
    public interface IEventUserRepository
    {
        Task<List<EventUser>> GetAllEventUserAsync();
        Task<EventUser> GetEventUserById(int id);
        Task CreateUserAsync(EventUser eventUser);
        Task RemoveUserAsync(EventUser eventUser);
        Task UpdateUserAsync(EventUser eventUser);
    }
}
