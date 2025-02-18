using EcoApi.Models;

namespace EcoApi.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(int id);
        Task<Role> GetRoleByName(string name);
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> CreateRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task<Role> DeleteRole(Role role);
    }
}
