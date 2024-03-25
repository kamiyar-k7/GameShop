using Domain.entities.UserPart.Roles;

namespace Application.Services.Interfaces.UserSide;

public interface IRoleService
{

    Task<bool> IsUserAdmin(int id);
}
