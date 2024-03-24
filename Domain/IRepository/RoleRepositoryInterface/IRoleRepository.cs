

using Domain.entities.UserPart.Roles;

namespace Domain.IRepository.RoleRepositoryInterface;

public interface IRoleRepository
{
    Task<List<Role>> GetUserRolesById(int Id);
}
