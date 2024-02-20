

using Application.DTOs.UserSide.Home;
using Domain.entities.Store.Game;

namespace Application.Services.Interfaces;

public interface IHomeService
{
	Task<List<HomeDto>> ShowGames();
}
