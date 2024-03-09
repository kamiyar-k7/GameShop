

using Application.ViewModel.UserSide;

namespace Application.Services.Interfaces;

public interface IHomeService
{
    Task<AboutPageViewModel?> ShowAbout();
    Task<bool> AddMessage(ContactUsViewModel aboutViewModel);
}
