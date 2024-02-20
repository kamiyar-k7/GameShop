

using Domain.entities.Store.Game;

namespace Domain.IRepository.HomeRepositoryInterface;



public interface IHomeRepository
{
	Task<List<Game>> GetListOfGames();
}
