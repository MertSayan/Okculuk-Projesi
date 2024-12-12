using Application.Constants;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces.UserInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OkculukContext _context;

        public UserRepository(OkculukContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            user.CreatedDate = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.Users
                .Where(x => x.DeletedDate == null)
                .Include(x=>x.Role)
                .ToListAsync();
        }

        public async Task<List<GetAllUserByEventUserIdQueryResult>> GetAllUserByEventUserId(int eventId)
        {
            return await _context.EventsAndUsers
                 .Where(x=>x.EventId == eventId && x.DeletedDate==null)
                 .Include(x=>x.User)
                 .ThenInclude(x=>x.Role)
                 .Select(x=> new GetAllUserByEventUserIdQueryResult
                 {
                     UserId = x.UserId,
                     Email=x.User.Email,
                     Surname=x.User.Surname,
                     Name=x.User.Name,
                     PhoneNumber=x.User.PhoneNumber,
                     RoleName=x.User.Role.RoleName
                 }).ToListAsync();
                 
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users
                    .Where(x=>x.DeletedDate==null)
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync(x => x.UserId == id);
 
            if (user !=null)
            {
                return user;
            }
            return null;
        }

        public async Task RemoveUserAsync(User user)
        {
            if (user.DeletedDate == null)
            {
                user.DeletedDate= DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(Messages<User>.EntityAlreadyDeleted);
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            user.UpdatedDate = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
