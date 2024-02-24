using Domain.entities.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.ProductRepositoryInterface
{
    public interface IProductRepository
    {
        #region General
        Task<List<Game>> GetGames();
        Task<Game> GetGameById(int Id);
        #endregion
    }
}
