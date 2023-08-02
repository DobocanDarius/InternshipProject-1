using DataAccess.Models;

namespace DataAccess.Data;

public interface IPostData
{
    Task<IEnumerable<PostModel>> GetPosts();
}