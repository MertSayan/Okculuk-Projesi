using Application.Constants;
using Application.Features.Mediatr.Users.Results;
using Application.Interfaces.UserInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

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
                .Include(x=>x.Region)
                .ToListAsync();
        }

        public async Task<List<User>> GetPagedUserAsync(int pageNumber, int pageSize)
        {
            return await _context.Users
                .Where(x => x.DeletedDate == null)
                .Include(x => x.Role)
                .Include(x => x.Region)
                .OrderBy(x => x.Region.RegionName) // Şehir isimlerine göre alfabetik sırala
                .Skip((pageNumber - 1) * pageSize) // İlgili sayfa için kayıtları atla
                .Take(pageSize) // Sayfa başına veriyi al
                .ToListAsync();
        }



        public async Task<List<GetAllUserByEventIdQueryResult>> GetAllUserByEventUserId(int eventId)
        {
            return await _context.EventsAndUsers
                 .Where(x=>x.EventId == eventId && x.DeletedDate==null)
                 .Include(x=>x.User)
                 .ThenInclude(x=>x.Role)
                 .Select(x=> new GetAllUserByEventIdQueryResult
                 {
                     UserId = x.UserId,
                     Email=x.User.Email,
                     Surname=x.User.Surname,
                     Name=x.User.Name,
                     PhoneNumber=x.User.PhoneNumber,
                     RoleName=x.User.Role.RoleName,
                     Status=x.Status,
                     BasvuruZamani=x.BasvuruZamanı,
                     RejectedReason=x.RejectedReason
                 }).ToListAsync();
                 
        }

        public async Task<List<User>> GetAllUserByRegionId(string regionName)
        {
            var regionId = await _context.Regions
                 .Where(x => x.RegionName == regionName)
                 .Select(x => x.RegionId)
                 .FirstOrDefaultAsync();

            return await _context.Users
                .Where(x => x.DeletedDate == null && x.RegionId == regionId)
                .Include(x => x.Region)
                .ToListAsync();
        }

        public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter)
        {
            var user=await _context.Users.Where(filter)
                .Include(x=>x.Role)
                .FirstOrDefaultAsync();
            return user;
        }

   

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users
                    .Where(x=>x.DeletedDate==null)
                    .Include(x => x.Role)
                    .Include(x=>x.Region)
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
                // Kullanıcıyı soft delete yap
                user.DeletedDate = DateTime.Now;

                // İlişkili EventUser kayıtlarını soft delete yap
                var relatedEventUsers = _context.EventsAndUsers.Where(eu => eu.UserId == user.UserId && eu.DeletedDate == null).ToList();
                foreach (var eventUser in relatedEventUsers)
                {
                    eventUser.DeletedDate = DateTime.Now;
                }

                // Kullanıcının sahibi olduğu Event'leri soft delete yap
                var relatedEvents = _context.Events.Where(e => e.UserId == user.UserId && e.DeletedDate == null).ToList();
                foreach (var eventEntity in relatedEvents)
                {
                    eventEntity.DeletedDate = DateTime.Now;

                    // Silinen etkinliğe bağlı EventUser kayıtlarını da soft delete yap
                    var eventUsersForDeletedEvent = _context.EventsAndUsers.Where(eu => eu.EventId == eventEntity.EventId && eu.DeletedDate == null).ToList();
                    foreach (var eventUser in eventUsersForDeletedEvent)
                    {
                        eventUser.DeletedDate = DateTime.Now;
                    }
                }

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
