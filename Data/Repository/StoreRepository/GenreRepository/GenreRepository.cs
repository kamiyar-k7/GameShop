﻿using Data.ShopDbcontext;
using Domain.entities.GamePart.GemGenreDto;
using Domain.entities.Store.Game;
using Domain.IRepository.GenreRepostoryInterface;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository.StoreRepository.GenreRepository;

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
        return await _gameShopDbContext.genres.ToListAsync();

    }
    public async Task<List<Genre>> GetGenresById(int Id)
    {
        return await _gameShopDbContext.SelectedGenres.Where(x => x.GameId == Id).Select(x => x.Genre).ToListAsync();
    }
    public async Task<List<Game>> GetGamesByGenres(List<Genre> genres)
    {
        var games = await _gameShopDbContext.games
       .Where(game => game.gameSelectedGenres
           .Any(GenreDto => genres.Select(g => g.Id).Contains(GenreDto.GenreId)))
       .ToListAsync();
        return games;
    }
    #endregion
}
