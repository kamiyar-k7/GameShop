

using Domain.entities.UserPart.Roles;

namespace Application.Services.Interfaces;

public interface IRoleService
{

    Task<bool> IsUserAdmin(int id);
}
