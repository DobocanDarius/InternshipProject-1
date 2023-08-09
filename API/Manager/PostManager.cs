using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Comments.Response;
using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;
using RequestResponseModels.Topics.Request;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace WebApi.Manager;

public class PostManager : IPostManager
{
    private readonly IPost _postRepository;

    public PostManager(IPost postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<GetPostResponse>> GetPosts()
    {
        var posts = await _postRepository.GetPosts();

        var response = posts.Select(p => new GetPostResponse(
            p.Id,
            p.Title,
            p.Body,
            p.UserId,
            p.UpVotes,
            (DateTime)p.CreatedAt,
            p.TopicId

        ));

        return response;
    }
    public async Task<IEnumerable<GetPostResponse>> GetPostsByTopic(int id)
    {
        var posts = await _postRepository.GetPostByTopic(id);

        var response = posts.Select(p => new GetPostResponse(
            p.Id,
            p.Title,
            p.Body,
            p.UserId,
            p.UpVotes,
            (DateTime)p.CreatedAt,
            p.TopicId

        ));

        return response;
    }
    public async Task InsertPost(InsertPostRequest newPost)
    {
        var post = new DataAccess.Models.Post
        {
            Title = newPost.Title,
            Body = newPost.Body,
            UserId = newPost.UserId,
            TopicId = newPost.TopicId
        };
        await _postRepository.InsertPost(post);
    }

    public async Task UpdatePost(UpdatePostRequest post, int id)
    {
        var postToUpdate = new DataAccess.Models.Post
        {
            Title = post.Title,
            Body = post.Body,
        };

        await _postRepository.UpdatePost(postToUpdate, id);
    }

    public async Task UpVotePost(int id)
    {
        await _postRepository.UpVotePost(id);
    }

    public async Task DeletePost(int id)
    {
        await _postRepository.DeletePost(id);
    }

}
