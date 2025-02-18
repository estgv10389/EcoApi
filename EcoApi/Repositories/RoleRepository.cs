using EcoApi.Data;
using EcoApi.Models;
using EcoApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoApi.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FindAsync(id) ?? throw new KeyNotFoundException($"Role with id {id} not found.");
        }

        public async Task<Role> GetRoleByName(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name) ?? throw new KeyNotFoundException($"Role with name {name} not found.");
        }

        public async Task<Role> CreateRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
    }
}
