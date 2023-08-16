using DataAccess.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ISqlDataAccess _db;

        public TopicRepository(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<IEnumerable<Models.Topic>> GetTopics() =>
        _db.LoadData<Models.Topic, dynamic>("dbo.sp_TopicGetAll", new { });

        public Task InsertTopic(Models.Topic topic) =>
            _db.SaveData("dbo.sp_TopicInsert", new { topic.Text });

        public Task DeleteTopic(int id) =>
            _db.SaveData("dbo.sp_TopicDelete", new { Id = id });
    }
}
