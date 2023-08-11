﻿using Newtonsoft.Json;
using RequestResponseModels.Comments.Response;
using RequestResponseModels.Posts.Response;
using System.Text;
using UI.Helpers;

namespace UI.Services
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _client;

        public CommentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CommentResponse>> FindByPost(int postId)
        {
            var response = await _client.GetAsync($"/api/Comment/{postId}");
            return await response.ReadContentAsync<List<CommentResponse>>();
        }
    }
}
