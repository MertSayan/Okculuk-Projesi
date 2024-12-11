using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserById(int id);
        Task CreateUserAsync(User user);
        Task RemoveUserAsync(User user);
        Task UpdateUserAsync(User user);

    }
}
