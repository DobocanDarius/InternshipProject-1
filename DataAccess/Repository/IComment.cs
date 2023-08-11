namespace DataAccess.Repository
{
    public interface IComment
    {
        Task DeleteComment(int id);
        Task<IEnumerable<Models.Comment?>> GetCommentByPost(int id);
        Task<IEnumerable<Models.Comment>> GetComments();
        Task InsertComment(Models.Comment comment);
        Task UpdateComment(Models.Comment comment, int id);
    }
}