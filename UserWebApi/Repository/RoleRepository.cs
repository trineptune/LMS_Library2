using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using UserWebApi.Data;
using UserWebApi.Models;
using UserWebApi.Service;

namespace UserWebApi.Repository
{
    public class RoleRepository : IRole
    {
        private readonly UserDbContext _context;
        public RoleRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<RoleDTO> AddRole(RoleDTO roleDto)
        {
            var newRole = new Role
            {
                RoleName = roleDto.RoleName,
                Description=roleDto.Description
            };
            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();

            return roleDto;
        }

        public async Task<bool> UpdateRole(int id,RoleDTO roleDTO)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return false;
            }

            role.Description = roleDTO.Description;
            role.RoleName = roleDTO.RoleName;   

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }
            
           _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
