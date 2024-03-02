using Application.DTOs.UserSide.Account;
using Application.Helpers;
using Application.Services.Interfaces;
using Domain.entities.UserPart.User;
using Domain.IRepository.AccountRepositorieInterfaces;


namespace Application.Services.implements;

public class AccountService : IAccountService
{
    #region Ctor
     private readonly IAccountRepository _account;
    public AccountService(IAccountRepository repository)
    {
      _account = repository;
    }
    #endregion


    #region General
    public async Task<SignInDto> FindUser(SignInDto model)
    {
        User usercheck = new User()
        {
            Password = PassHelper.EncodePasswordMd5(model.Password),
            Email = model.Email,

        };


        var user = await _account.FindUser(usercheck);
        if (user != null)
        {
            SignInDto signInDto = new SignInDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                IsAdmin = user.IsAdmin,
                PhoneNumber = user.PhoneNumber,
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



    #region ADD TO DATABASE

    public bool IsExist(string phonenumber, string email)
    {
        return _account.IsExist(phonenumber, email);
    }
    public User FillEntity(SignUpDto model)
    {
        User user = new User();
        user.UserName = model.UserName;
        user.Email = model.Email;
        user.Password = PassHelper.EncodePasswordMd5(model.Password);
        user.PhoneNumber = model.PhoneNumber;

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

                await _account.AddToDataBase(user, cancellation);
                await _account.SaveChanges();
                return true;
            }

            return false;


        }

        return false;
    }
    #endregion

}
#endregion
