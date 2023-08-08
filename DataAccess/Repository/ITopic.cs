namespace DataAccess.Repository
{
    public interface ITopic
    {
        Task DeleteTopic(int id);
        Task<IEnumerable<Models.Topic>> GetTopics();
        Task InsertTopic(Models.Topic topic);
    }
}