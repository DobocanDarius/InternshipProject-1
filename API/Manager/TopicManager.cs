using DataAccess.Repository;
using RequestResponseModels.Posts.Response;
using RequestResponseModels.Topics.Request;
using RequestResponseModels.Topics.Response;

namespace API.Manager;

public class TopicManager : ITopicManager
{
    private readonly ITopic _topicRepository;

    public TopicManager(ITopic topicRepository)
    {
        _topicRepository = topicRepository;
    }
    public async Task<IEnumerable<GetTopicResponse>> GetTopics()
    {
        var posts = await _topicRepository.GetTopics();

        var response = posts.Select(p => new GetTopicResponse(p.Id, p.Text));

        return response;
    }
    public async Task InsertTopic(GetTopicRequest newTopic)
    {
        var topic = new DataAccess.Models.Topic
        {
            Text = newTopic.Text
        };
        await _topicRepository.InsertTopic(topic);
    }


    public async Task DeleteTopic(int id)
    {
        await _topicRepository.DeleteTopic(id);
    }
}
