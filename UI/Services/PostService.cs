
using Newtonsoft.Json;
using RequestResponseModels.Posts.Request;
using RequestResponseModels.Posts.Response;
using System.Text;
using UI.Helpers;

namespace UI.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Post";

        public PostService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<GetPostResponse>> Find()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<GetPostResponse>>();
        }

        public async Task<IEnumerable<GetPostResponse>> FindByTopic(int topicId)
        {
            var response = await _client.GetAsync($"/api/Post/{topicId}");
            return await response.ReadContentAsync<List<GetPostResponse>>();
        }

        public async Task<IEnumerable<GetPostResponse>> FindByUser(int userId)
        {
            var response = await _client.GetAsync($"/api/Post/User/{userId}");
            return await response.ReadContentAsync<List<GetPostResponse>>();
        }

        public async Task<HttpResponseMessage> CreatePost(InsertPostRequest post)
        {
            var json = JsonConvert.SerializeObject(post);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(BasePath, content);
            return response;
        }
        public async Task<HttpResponseMessage> DeletePost(int postId)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{postId}");
            return response;
        }

        public async Task<HttpResponseMessage> UpdatePost(int postId, UpdatePostRequest newPost)
        {
            var json = JsonConvert.SerializeObject(newPost);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"{BasePath}/{postId}", content);
            return response;
        }

        public async Task<HttpResponseMessage> UpVotePost(int postId)
        {
            var response = await _client.PutAsync($"{BasePath}/{postId}/upvote", null);
            return response;
        }

    }
}
