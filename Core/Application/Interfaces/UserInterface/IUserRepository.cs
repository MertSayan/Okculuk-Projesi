using Application.Features.Mediatr.Users.Results;
using Domain;
using System.Linq.Expressions;

namespace Application.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserById(int id);
        Task CreateUserAsync(User user);
        Task RemoveUserAsync(User user);
        Task UpdateUserAsync(User user);

        Task<List<GetAllUserByEventIdQueryResult>> GetAllUserByEventUserId(int eventId);

        Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter); //şimdilik login işlemi için kullanacağım
                                                                          //tabiki bu kullanım filitre olduğu için farklı parametrelere göre de listeleyebilirim

        Task<List<User>> GetAllUserByRegionId(string regionName);


    }
}
