

using Application.DTOs.UserSide.Home;


namespace Application.Services.Interfaces;

public interface IHomeService
{
	Task<List<HomeDto>> ShowGames();
}
