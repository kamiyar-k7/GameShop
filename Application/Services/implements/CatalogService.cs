using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Domain.IRepository.CatalogRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.implements
{
    public class CatalogService : ICatalogService
    {
        #region Ctor
        private readonly ICatalogRepository _catalogRepository;
        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }
        #endregion

        #region Genreal
        public async Task<List<CatalogDto>> ShowGames()
        {
            var listofgames = await _catalogRepository.GetListOfGames();
            if (listofgames != null)
            {
                List<CatalogDto> model = new List<CatalogDto>();

                foreach (var game in listofgames)
                {
                    CatalogDto childmodel = new CatalogDto()
                    {
                        Id = game.Id,
                        Name = game.Name,
                        Description = game.Description,
                        Price = game.Price,
                        Rating = game.Rating,
                        ReleaseDate = game.ReleaseDate,
                        Screenshots = new List<string>(),
                      

                    };

                    foreach (var screenshots in game.Screenshots)
                    {
                        childmodel.Screenshots.Add(screenshots.AvararUrl);
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
