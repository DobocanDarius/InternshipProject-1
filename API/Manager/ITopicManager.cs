using RequestResponseModels.Topics.Request;
using RequestResponseModels.Topics.Response;

namespace API.Manager
{
    public interface ITopicManager
    {
        Task DeleteTopic(int id);
        Task<IEnumerable<GetTopicResponse>> GetTopics();
        Task InsertTopic(GetTopicRequest newTopic);
    }
}