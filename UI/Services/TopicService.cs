using RequestResponseModels.Posts.Response;
using RequestResponseModels.Topics.Response;
using UI.Helpers;

namespace UI.Services;

public class TopicService : ITopicService
{
    private readonly HttpClient _client;
    public const string BasePath = "/api/Topic";

    public TopicService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }


    public async Task<IEnumerable<GetTopicResponse>> Find()
    {
        var response = await _client.GetAsync(BasePath);

        return await response.ReadContentAsync<List<GetTopicResponse>>();
    }
}
