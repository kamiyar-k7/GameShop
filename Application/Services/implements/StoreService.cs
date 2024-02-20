using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Domain.IRepository.StoreRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.implements
{
    public class StoreService : IStoreService
    {
        #region ctor
        private readonly IStoreRepositpory _storeRepository;

        public StoreService(IStoreRepositpory store)
        {
                _storeRepository = store;
        }
        #endregion

        #region General

        public async Task<List<StoreDto>> ShowGames()
        {
            #region Get list of games 
            var games = await _storeRepository.GetListOfGames();

            #endregion
            if(games != null)
            {
                List<StoreDto> model = new List<StoreDto>();
                foreach (var game in games)
                {
                    StoreDto childmodel = new StoreDto()
                    {
                        Id = game.Id,
                        Name = game.Name,
                        Description = game.Description,
                        Price = game.Price,
                        Rating = game.Rating,
                        Screenshots = new List<string>(),
                        ReleaseDate = game.ReleaseDate
                       

                    };
                    foreach (var screenshot in game.Screenshots)
                    {
                        childmodel.Screenshots.Add(screenshot.AvararUrl);
                    }
                    model.Add(childmodel);  
                }
                return model;
            }
            return null;
        }

        #endregion
    }
}
