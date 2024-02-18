using Application.DTOs.AdminSide.Account;
using Domain.entities.UserPart.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
	public interface iSignUpService
	{
		#region general
		Task<bool> AddToDataBase(SignUpDto model, CancellationToken cancellation);
		//bool IsExist(long phonenumber, string email);
		//User FillEntity(SignUpDto model);
		#endregion

	}
}
