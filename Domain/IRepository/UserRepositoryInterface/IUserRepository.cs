using Domain.entities.UserPart.User;

namespace Domain.IRepository.UserRepositoryInterface;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(int id);
    Task SaveChanges();
}
