namespace DataAccess.Repository
{
    public interface ITopicRepository
    {
        Task DeleteTopic(int id);
        Task<IEnumerable<Models.Topic>> GetTopics();
        Task InsertTopic(Models.Topic topic);
    }
}