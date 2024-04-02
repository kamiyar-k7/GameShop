
using Application.DTOs.UserSide.Account;
using Application.Helpers;
using Application.Services.Interfaces.UserSide;
using Application.ViewModel.AdminSide;
using Application.ViewModel.UserSide;
using Domain.entities.UserPart.Roles;
using Domain.entities.UserPart.User;

using Domain.IRepository.GamePart;
using Domain.IRepository.UserPart;


namespace Application.Services.implements.UserSide;

public class AccountService : IAccountService
{
    #region Ctor
    private readonly IAccountRepository _account;
    private readonly IGameRepository _game;

    public AccountService(IAccountRepository repository, IGameRepository gameRepository)
    {
        _account = repository;
        _game = gameRepository;

    }
    #endregion


    #region General

    #region SignIN

    public async Task<SignInDto> FindUser(SignInDto model)
    {
        User usercheck = new User()
        {
            Password = PassHelper.EncodePasswordMd5(model.Password),
            Email = model.Email,

        };


        var user = await _account.FindUserSignIn(usercheck);
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
    #endregion

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
        user.PhoneNumber = model.PhoneNumber.Trim();
       

        user.UserSelectedRoles = new List<UserSelectedRole>();

        var userSelectedRole = new UserSelectedRole
        {
            RoleId = 3 
        };

     
        user.UserSelectedRoles.Add(userSelectedRole);

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

    #region User Deatails 

    public async Task<UserAccountViewModel> UserViewModel(int id)
    {
        var user = await _account.GetUserByIdAsync(id);

        List<UserCommentsViewModel> comments = new List<UserCommentsViewModel>();


        if (user != null)
        {

            var detailmodel = new UserDeatailViewModel()
            {
                UserId = id,
                Name = user.UserName,
                Avatar = user.UserAvatar,
                DateTime = user.Created,
                Email = user.Email,

            };

            foreach (var com in user.Comments)
            {
                var game = await _game.GetGameById(com.GameId);
                var commentsmodel = new UserCommentsViewModel()
                {
                    Comment = com.Comment,
                    CreatedAt = com.CreatedAt,
                    GameName = game.Name,
                    GameId = com.GameId,
                    Ratings = com.Ratings,
                    Title = com.Title,
                };
                comments.Add(commentsmodel);
            }

            UserAccountViewModel model = new UserAccountViewModel()
            {
                Deatail = detailmodel,
                Comments = comments
            };
            return model;


        }

        return null;

    }

    #endregion

    #region Edit Details 
    public async Task<bool> UpdateDetails(UserDeatailViewModel model)
    {
        var user = await _account.GetUserByIdAsync(model.UserId);
        if (user != null)
        {
            user.UserName = model.Name;

            if (model.AvatarForm != null)
            {

                //Save New Image
                user.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.AvatarForm.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/UserAvatar", user.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.AvatarForm.CopyTo(stream);
                }

            }

            _account.Update(user);
            await _account.SaveChanges();

            return true;
        }
        return false;

    }

    #endregion




    //------------------------------------------

    #region Admin Side

    public async Task<AdminInformationViewModel> AdminInfoView(int id)
    {
        var admin = await _account.GetUserByIdAsync(id);

        AdminInformationViewModel adminview = new AdminInformationViewModel()
        {
            DateTime = admin.Created,
            Email = admin.Email,
            Id = id,
            PhoneNumber = admin.PhoneNumber,
            UserAvatar = admin.UserAvatar,
            UserName = admin.UserName,

        };

        return adminview;
    }

    #endregion
}
#endregion
