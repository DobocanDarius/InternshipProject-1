namespace DataAccess.Repository
{
    public interface IPost
    {
        Task DeletePost(int id);
        Task<IEnumerable<Models.Post?>> GetPostByTopic(int id);
        Task<IEnumerable<Models.Post>> GetPosts();
        Task InsertPost(Models.Post post);
        Task UpdatePost(Models.Post post, int id);
        Task UpVotePost(Models.Post post, int id);
    }
}