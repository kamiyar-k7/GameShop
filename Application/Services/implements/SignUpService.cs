using Application.DTOs.AdminSide.Account;
using Application.Helpers;
using Application.Services.Interfaces;
using Domain.entities.UserPart.User;
using Domain.IRepository.AccountRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.implements
{
	public class SignUpService  : ISignUpService
	{
		#region Ctor
		private readonly ISignUpRepository _signUpRepository;

        public   SignUpService(ISignUpRepository signUpRepository  )
        { 
            _signUpRepository = signUpRepository;
        }
		#endregion

		#region Genera
		#region Sign Up
		public bool IsExist(string phonenumber, string email)
		{
			return _signUpRepository.IsExist(phonenumber, email);
		}
		public User FillEntity(SignUpDto model)
		{
			User user = new User();
			user.UserName = model.UserName;
			user.Email = model.Email;
			user.Password = PassHelper.EncodePasswordMd5(model.Password);
			user.PhoneNumber = model.PhoneNumber.Trim();

			return user;
		}

		public async Task<bool> AddToDataBase(SignUpDto model, CancellationToken cancellation)
		{

			if (model != null)
			{

				var exist = IsExist(model.PhoneNumber, model.Email);


				if (exist != true)
				{
					var user = FillEntity(model);

					await _signUpRepository.AddToDataBase(user, cancellation);
					await _signUpRepository.SaveChanges();
					return true;
				}

				return false;


			}

			return false;
		}
		#endregion

		#endregion
	}
}
