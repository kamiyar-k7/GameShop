using Application.Services.Interfaces.AdminSide;
using Application.Services.Interfaces.UserSide;
using Application.ViewModel.AdminSide;
using Application.ViewModel.UserSide;
using Domain.entities.Comments;
using Domain.entities.GamePart.Game;
using Domain.entities.GamePart.Genre;
using Domain.IRepository.GamePart;




namespace Application.Services.implements.SitteSide;

public class ProductService : IProductService
{
    #region Ctor
    private readonly IGameRepository _gamerepository;
    private readonly IPlatformRepository _platformRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly ILayoutService _layoutService;
    private readonly  IPlatformService _platformService;
    private readonly  IGenreService _genreService;

    public ProductService(IGameRepository gameRepository,
        IPlatformRepository platformRepository,
        IGenreRepository genreRepository,
       ICommentRepository commentRepository,
       ILayoutService layoutService,
       IGenreService genreService ,
       IPlatformService platformService)
    {
        _gamerepository = gameRepository;
        _platformRepository = platformRepository;
        _genreRepository = genreRepository;
        _commentRepository = commentRepository;
        _layoutService = layoutService;
        _genreService = genreService;
        _platformService = platformService;
    }
    #endregion

    #region General 






    #endregion

    #region Game Details
    // get game by id 
    public async Task<Game> GetGameAsync(int Id)
    {
        var Game = await _gamerepository.GetGameById(Id);
        return Game;
    }
    // fill game model 
    public async Task<GameViewModelProduct> fillgame(int Id)
    {
        var Game = await _gamerepository.GetGameById(Id);
        GameViewModelProduct gameViewModel = new GameViewModelProduct();
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
            return gameViewModel;
        }
        return null;
    }

    // fill comments model 
    public async Task<List< CommentsViewModelProduct>> FillComment(int Id)
    {
        var game = await GetGameAsync(Id);
        var comments = await _commentRepository.GetCommentsAsync(game.Id);
        List<CommentsViewModelProduct> listofcomments = new List<CommentsViewModelProduct>();
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

            return listofcomments;
        }
        return null;
    }

    // fill Platforms \

    public  async Task<List<PlatformViewModelProduct>> FillPlatform(int Id)
    {
        var platforms = await _platformRepository.GetPlatformsById(Id);
        List<PlatformViewModelProduct> listofplatforms = new List<PlatformViewModelProduct>();
        if (platforms != null)
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
            return listofplatforms;
        }
        return null;
    }

    // fill Genres 
    public async Task<List<GenreViewModelProduct>> FillGenre(int Id)
    {
       var Genres = await _genreRepository.GetGenresById(Id);
        List<GenreViewModelProduct> listofgenres = new List<GenreViewModelProduct>();
        if (Genres != null)
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
            return listofgenres;
        }
        return null;
    }

    // fill Related GAmes 
    public async Task<List<RelatedGamesProduct>> FillRelated(int Id)
    {
        var game1 = await GetGameAsync(Id);
        var related = await _gamerepository.GetRelatedGamesBtGenre(game1);
        List<RelatedGamesProduct> relatedGames = new List<RelatedGamesProduct>();
        if (relatedGames != null)
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
            return relatedGames;

        }
        return null;
    }

    public async Task<ProductViewModel> GetProductById(int Id , int Adminid  )
    {


        var gameModel = await fillgame(Id);

        var Game = await GetGameAsync(Id);

        var platforms = await FillPlatform(Id);

        var Genres = await FillGenre(Id);

        var related = await FillRelated(Id);

        var comments = await FillComment(Id);

     //   var admin = await _layoutService.AdminInfo(userid);

        if (Game != null)
        {

            
			ProductViewModel model = new ProductViewModel()
            {
                Game = gameModel,
                Platforms = platforms,
                Genres = Genres,
                RelatedGames = related,
                Comments = comments,
    
                
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

    public async Task<bool> SubmitComment(CommentsViewModelProduct model)
    {

        if (model != null)
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


    #region Admin Side

    // fill lits of games
    public async Task<List<GameViewModelProduct>> ListOfGames()
    {
        var games = await _gamerepository.GamesAsync();

        List<GameViewModelProduct> model = new List<GameViewModelProduct>();

        foreach (var Game in games)
        {
            GameViewModelProduct childmodel = new GameViewModelProduct()
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
                childmodel.ScreenShots.Add(item.AvararUrl);
            }
            model.Add(childmodel);
        }
        return model;

    }

    public async Task<ProductViewModel> ListOfProducts(int userid)
    {
        var admin = await _layoutService.AdminInfo(userid);
        var games = await ListOfGames();
       



        ProductViewModel adminProductViewModel = new ProductViewModel()
        {
            Admin = admin,
            ListGames = games,
            
        };

        return adminProductViewModel;
    }

    

    public async Task<ProductViewModel> ShowAddGame(int id)
    {
        var admin = await _layoutService.AdminInfo(id);
        var plats = await _platformService.ShowPlatform();
        var genres = await _genreService.ShowGenre();

        #region Object mapping 

       


        #endregion

        ProductViewModel adminGameViewModel = new ProductViewModel()
        {
            Admin = admin,
           
        };
        return adminGameViewModel;
    }

    #endregion

}
