using Domain;

namespace Application.Interfaces.RoleInterface
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRole();
        Task<Role> GetRoleById(int id);
        Task CreateRole(Role role);   
        Task UpdateRole (Role role);
        Task DeleteRole (Role role);
    }
}
