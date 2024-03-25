

using Application.ViewModel.AdminSide;

namespace Application.Services.Interfaces.AdminSide;

public interface IAdminHomeService
{
    CountsViewModel DashboardView();
    Task<List<ContactMessagesViewModel>> Messages();
    Task<bool> DeleteMessage(int id);
}
