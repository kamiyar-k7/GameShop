using Domain.entities.GamePart.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.GamePart
{
    public interface IGameRepository
    {
        #region General
        Task<List<Game>> GamesAsync();
        Task<Game?> GetGameById(int id);
        Task<List<Game>> GetRelatedGamesBtGenre(Game game);
        #endregion


        #region Admin Side
        public int GameCount();
        Task SaveChanges();
        Task AddNewGame(Game game);

        #endregion

    }
}
