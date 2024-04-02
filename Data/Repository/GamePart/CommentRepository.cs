using Data.ShopDbcontext;
using Domain.entities.Comments;
using Domain.IRepository.GamePart;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.GamePart;

public class CommentRepository : ICommentRepository
{

    #region Ctor
    private readonly GameShopDbContext _dbcontext;
    public CommentRepository(GameShopDbContext gameShop)
    {
        _dbcontext = gameShop;
    }

    #endregion

    #region Generel

    public async Task<List<Comments>> GetCommentsAsync(int gameid)
    {
        return await _dbcontext.Comments.Include(x => x.User).Where(x => x.GameId == gameid).OrderByDescending(x => x.CreatedAt).ToListAsync();
    }

    public async Task AddComment(Comments comments)
    {
        await _dbcontext.Comments.AddAsync(comments);
        await _dbcontext.SaveChangesAsync();
    }
    #endregion
}
