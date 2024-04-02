using Domain.entities.Comments;

namespace Domain.IRepository.GamePart;

public interface ICommentRepository
{

    Task<List<Comments>> GetCommentsAsync(int gameid);
    Task AddComment(Comments comments);
}
