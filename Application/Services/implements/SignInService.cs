using Application.DTOs.UserSide.Account;
using Application.Helpers;
using Application.Services.Interfaces;
using Domain.entities.UserPart.User;
using Domain.IRepository.AccountRepositorieInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.implements
{
    public class SignInService : ISignInService
    {
        #region Ctor 
        private readonly ISignInRepository _SignInRepository;
        public SignInService(ISignInRepository signInRepository)
        {
            _SignInRepository = signInRepository;
        }
        #endregion

        #region General
        public async Task<SignInDto> FindUser(SignInDto model )
        {
            User usercheck = new User()
            {
                Password = PassHelper.EncodePasswordMd5(model.Password),
                Email = model.Email,
            
            };
         
         
            var user = await _SignInRepository.FindUser(usercheck); 
            if (user != null)
            {
                SignInDto signInDto = new SignInDto()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    IsAdmin = user.IsAdmin,
                    PhoneNumber = user.PhoneNumber.Trim(),
                    Password = user.Password,
                    Email = user.Email,
                    //Role = model.Role,
                    SuperAdmin = user.SuperAdmin,
                    UserAvatar = user.UserAvatar
                };
                return signInDto;
                
            }
            return null;
        }
        #endregion
    }
}
