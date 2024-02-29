

using Domain.entities.GamePart.Game;

namespace Domain.IRepository.HomeRepositoryInterface;



public interface IHomeRepository
{
	Task<List<Game>> GetListOfGames();
}
