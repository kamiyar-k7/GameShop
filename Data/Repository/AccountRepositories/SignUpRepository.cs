using Domain.entities.UserPart.User;
using Domain.IRepository.AccountRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.AccountRepositories
{
	public class SignUpRepository : ISignUpRepository
	{
        #region Ctor
        private readonly ShopDbcontext.GameShopDbContext _dbContext;
        public SignUpRepository(ShopDbcontext.GameShopDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		#endregion

		#region general
		
		public async Task SaveChanges()
		{ 
			await _dbContext.SaveChangesAsync();
		}
		public async Task<List<User>> GetListOfUsers(CancellationToken cancellationToken)
		{
			return await _dbContext.Users.Where(x => x.IsDelete != false).ToListAsync(cancellationToken);
		}
		public async Task AddToDataBase(User user, CancellationToken cancellation)
		{
		 await	_dbContext.AddAsync(user);
		}

		 public  bool IsExist(string PhoneNumber, string email  )
		{
			return _dbContext.Users.Any(x => x.PhoneNumber == PhoneNumber || x.Email == email);
			
		}
		
		#endregion
	}
}
