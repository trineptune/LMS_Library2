using UserWebApi.Models;

namespace UserWebApi.Repository
{
    public interface IRole
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<RoleDTO> AddRole(RoleDTO roleDto);
        Task<bool> UpdateRole(int id,RoleDTO roleDTO);
        Task<bool> DeleteRole(int id);
    }
}
