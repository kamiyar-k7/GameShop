using Domain.entities.WebSite;
namespace Domain.IRepository.HomeRepositoryInterface;


public interface IHomeRepository
{
    Task<AboutUs?> AboutUs();
    Task ContactUs(ContactUs contactUs);

}

