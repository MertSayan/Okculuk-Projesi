using Application.Constants;
using Application.Enums;
using Application.Interfaces.RoleInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.RoleRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly OkculukContext _context;

        public RoleRepository(OkculukContext context)
        {
            _context = context;
        }

        public async Task CreateRole(Role role)
        {
            role.CreatedDate= DateTime.Now; 
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteRole(Role role)
        {
            if (role.DeletedDate == null)
            {
                role.DeletedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(Messages<Rol>.EntityAlreadyDeleted);
            }
        }

        public async Task<List<Role>> GetAllRole()
        {
            return await _context.Roles
                .Where(x => x.DeletedDate == null)
                .ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            var role=await _context.Roles
                .Where(x=>x.DeletedDate==null)
                .FirstOrDefaultAsync(x=>x.RoleId==id);

            if (role != null)
            {
                return role;
            }
            return null;
        }

        public async Task UpdateRole(Role role)
        {
            role.UpdatedDate = DateTime.Now;
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
