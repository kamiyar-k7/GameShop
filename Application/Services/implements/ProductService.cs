using Application.Services.Interfaces;
using Application.ViewModel.UserSide;
using Domain.entities.Comments;
using Domain.entities.GamePart.Game;
using Domain.IRepository.CommentRepositoryInterface;
using Domain.IRepository.GameRepositoryInteface;
using Domain.IRepository.GenreRepostoryInterface;
using Domain.IRepository.PlatformRepositoryInterface;



namespace Application.Services.implements;

public class ProductService : IProductService
{
    #region Ctor
    private readonly IGameRepository _gamerepository;
    private readonly IPlatformRepository _platformRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly ICommentRepository _commentRepository;

    public ProductService(IGameRepository gameRepository,
        IPlatformRepository platformRepository,
        IGenreRepository genreRepository,
       ICommentRepository commentRepository)
    {
        _gamerepository = gameRepository;
        _platformRepository = platformRepository;
        _genreRepository = genreRepository;
        _commentRepository = commentRepository;
    }
    #endregion


    #region General 
   

    public async Task<ProductViewModel> GetProductById(int Id)
    {

        var Game = await _gamerepository.GetGameById(Id);
        var platforms = await _platformRepository.GetPlatformsById(Id);
        var Genres = await _genreRepository.GetGenresById(Id);
        var related = await _gamerepository.GetRelatedGamesBtGenre(Game);
        var comments = await _commentRepository.GetCommentsAsync(Game.Id);

        if (Game != null)
        {
            #region Object Mpping
            GameViewModelProduct gameViewModel = new GameViewModelProduct();
            List<CommentsViewModelProduct> listofcomments = new List<CommentsViewModelProduct>();
            List<PlatformViewModelProduct> listofplatforms = new List<PlatformViewModelProduct>();
            List<GenreViewModelProduct> listofgenres = new List<GenreViewModelProduct>();
            List<RelatedGamesProduct> relatedGames = new List<RelatedGamesProduct>();
            #region Comment
            if (comments != null)
            {

                foreach (var item in comments)
                {

                    CommentsViewModelProduct commentmodel = new CommentsViewModelProduct()
                    {
                        Comment = item.Comment,
                        CreatedAt = DateTime.UtcNow,
                        Title = item.Title,
                        UserName = item.User.UserName,
                        Ratings = item.Ratings,
                        UserAvatar = item.User.UserAvatar,


                    };
                    listofcomments.Add(commentmodel);
                }


            }
            #endregion

            #region Game
            if (Game != null)
            {
                 gameViewModel = new GameViewModelProduct()
                {
                    Company = Game.Company,
                    Description = Game.Description,
                    Name = Game.Name,
                    Id = Game.Id,
                    Price = Game.Price,
                    Rating = Game.Rating,
                    ReleaseDate = Game.ReleaseDate,
                    SystemRequirements = Game.SystemRequirements,
                    Trailer = Game.Trailer,
                    ScreenShots = new List<string>()

                };
                foreach (var item in Game.Screenshots)
                {
                    gameViewModel.ScreenShots.Add(item.AvararUrl);
                }

            }


            #endregion

            #region Platform
            if(platforms != null)
            {
                foreach (var plats in platforms)
                {
                    PlatformViewModelProduct platformViewModel = new PlatformViewModelProduct()
                    {
                        Id = plats.Id,
                        Name = plats.Name,
                        PlatformUniqueName = plats.PlatformUniqueName,
                    };
                    listofplatforms.Add(platformViewModel);
                }
            }
        
            #endregion

            #region Genre
            if(Genres != null)
            {
                foreach (var genre in Genres)
                {
                    GenreViewModelProduct genreViewModel = new GenreViewModelProduct()
                    {
                        Id = genre.Id,
                        GenreName = genre.GenreName,
                        GenreUniqueName = genre.GenreUniqueName
                    };
                    listofgenres.Add(genreViewModel);
                }
            }
        
            #endregion

            #region Related Games
            if(relatedGames != null)
            {
                foreach (var game in related)
                {
                    RelatedGamesProduct relatedGamesmodel = new RelatedGamesProduct()
                    {
                        Description = game.Description,
                        Id = game.Id,
                        Name = game.Name,
                        Price = game.Price,
                        Rating = game.Rating,
                        ScreenShots = new List<string>(),
                    };
                    foreach (var screen in game.Screenshots)
                    {
                        relatedGamesmodel.ScreenShots.Add(screen.AvararUrl);
                    }
                    relatedGames.Add(relatedGamesmodel);
                }


            }
      
            #endregion

            #endregion


            ProductViewModel model = new ProductViewModel()
            {
                Game = gameViewModel,
                Platforms = listofplatforms,
                Genres = listofgenres ,
                RelatedGames = relatedGames,
                Comments = listofcomments

            };
        

            return model;

        }
        return null;
    }
    public async Task<List<CommentsViewModelProduct>> GetCommentsbyGameId(int Id)
    {
        var game = await _gamerepository.GetGameById(Id);
        var comments = await _commentRepository.GetCommentsAsync(game.Id);

        if (comments != null)
        {
            List<CommentsViewModelProduct> list = new List<CommentsViewModelProduct>();

            foreach (var item in comments)
            {

                CommentsViewModelProduct commentmodel = new CommentsViewModelProduct()
                {
                    Comment = item.Comment,
                    CreatedAt = DateTime.UtcNow,
                    Title = item.Title,
                    UserName = item.User.UserName,


                };
                list.Add(commentmodel);
            }

            return list;
        }
        return null;

    }

    public async Task<bool> SubmitComment(CommentsViewModelProduct model )
    {

        if(model != null)
        {
            Comments newcomment = new Comments()
            {
                Comment = model.Comment,
                CreatedAt = DateTime.UtcNow,
                Title = model.Title,
                GameId = model.GameId,
                Ratings = model.Ratings,
                UserId = model.UserId,
               
            };

            await _commentRepository.AddComment(newcomment);
            return true;
        }
        return false;
    }
  

    #endregion
}
