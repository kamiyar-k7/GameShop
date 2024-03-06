using Domain.entities.GamePart.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.GameRepository
{
    public interface IGameRepository
    {
        Task<List<Game>> GamesAsync();
        Task<Game?> GetGameById(int id);
        Task<List<Game>> GetRelatedGamesBtGenre(Game game);
        Task<List<Game>> FilterGames(string? SearchString, int? Platformid, int? GenreId, int? MaxPrice, int MinPrice);
    }
}
