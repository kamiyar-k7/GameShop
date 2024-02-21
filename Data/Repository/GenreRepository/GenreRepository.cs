using Data.ShopDbcontext;
using Domain.entities.GamePart.GemSelectedGenre;
using Domain.IRepository.GenreRepostoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.GenreRepository
{
    public class GenreRepository : IGenreRepository
    {
        #region Ctor
        private readonly GameShopDbContext _gameShopDbContext;
        public GenreRepository(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }
        #endregion

        #region general 
        public async Task<List<Genre>> GetGenre()
        {
            return   await _gameShopDbContext.genres.ToListAsync();
           
        }
        #endregion
    }
}
