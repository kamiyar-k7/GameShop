

using Application.Services.Interfaces.AdminSide;
using Application.ViewModel.AdminSide;
using Domain.IRepository.AccountRepositorieInterfaces;
using Domain.IRepository.GameRepositoryInteface;
using Domain.IRepository.HomeRepositoryInterface;

namespace Application.Services.implements.AdminSide;

public class AdminHomeService : IAdminHomeService
{
    #region Ctor
    private readonly IGameRepository _gameRepository;
    private readonly IAccountRepository _account;
    private readonly IHomeRepository _home;
    public AdminHomeService(IGameRepository gameRepository ,
                            IAccountRepository accountRepository,
                            IHomeRepository homeRepository)
    {
        
        _gameRepository = gameRepository;
        _account = accountRepository;
        _home = homeRepository;

    }
    #endregion

    #region Dashboard
 


    public CountsViewModel DashboardView()
    {

        var gamecount = _gameRepository.GameCount();
        var users = _account.CountUsers();
        var admins = _account.CountAdmins();

        CountsViewModel countsViewModel = new CountsViewModel()
        {
            GameCount = gamecount,
            AdminCount = admins,
            UserCount = users,
        };


        return countsViewModel;
    }
    #endregion



    #region Contact 

    public async Task<List<ContactMessagesViewModel>> Messages()
    {
        var messages = await _home.Messages();
        List<ContactMessagesViewModel> model = new List<ContactMessagesViewModel>();
        if (messages != null)
        {
            foreach (var message in messages)
            {
                ContactMessagesViewModel chiledmodel = new ContactMessagesViewModel()
                {
                    Id = message.Id,
                    UserName = message.Name,
                    Email = message.Email,
                    Title = message.Title,
                    Message = message.Message,
                    Time = message.DateTime,
                };
                model.Add(chiledmodel);
            }
            return model;


        }
        return null;
    }

    public async Task<bool> DeleteMessage(int id)
    {
        var result = await _home.DeleteMessage(id);
        if (result) { return true; }
        return false;
    }
    #endregion

}
