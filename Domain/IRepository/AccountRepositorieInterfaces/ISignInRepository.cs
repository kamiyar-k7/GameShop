using Domain.entities.UserPart.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.AccountRepositorieInterfaces
{
    public interface ISignInRepository
    {
        Task<User?> FindUser(User user);
    }
}
