using RequestResponseModels.Topics.Response;

namespace UI.Services
{
    public interface ITopicService
    {
        Task<IEnumerable<GetTopicResponse>> Find();
    }
}