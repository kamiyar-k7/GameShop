﻿using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Domain.IRepository.ProductRepositoryInterface;


namespace Application.Services.implements
{
    public class ProductService : IProductService
    {
        #region Ctor
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region General 



        public async Task<ProductDto> GetProductById(int Id)
        {

            var Game = await _productRepository.GetGameById(Id);
            if (Game != null)
            {
                ProductDto productDto = new ProductDto()
                {
                    Id = Game.Id,
                    Name = Game.Name,
                    Description = Game.Description,
                    Company = Game.Company,
                    Rating = Game.Rating,
                    ReleaseDate = Game.ReleaseDate,
                    Price = Game.Price,
                    SystemRequirements = Game.SystemRequirements,
                    Screenshots = new List<string>(),
                    Trailer = Game.Trailer


                };
                foreach (var scrennshot in Game.Screenshots)
                {
                    productDto.Screenshots.Add(scrennshot.AvararUrl);
                }


                return productDto;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
