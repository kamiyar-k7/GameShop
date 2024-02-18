using Domain.entities.UserPart.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.AccountRepositories
{
	public interface ISignUpRepository
	{
		#region Admin Side
		Task SaveChanges();
		Task AddToDataBase(User user , CancellationToken cancellation);
		Task<List<User>> GetListOfUsers(CancellationToken cancellationToken);
		bool IsExist(long PhoneNumbers , string email);
		#endregion

	}
}
