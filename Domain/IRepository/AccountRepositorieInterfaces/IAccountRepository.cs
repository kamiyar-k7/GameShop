using Domain.entities.UserPart.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.AccountRepositorieInterfaces
{
    public interface IAccountRepository
    {
        Task<User?> FindUser(User user);
        Task SaveChanges();
        Task AddToDataBase(User user, CancellationToken cancellation);
        bool IsExist(string PhoneNumbers, string email);
        Task<User?> GetUserByIdAsync(int id);
        void Update(User user);



    }
}
