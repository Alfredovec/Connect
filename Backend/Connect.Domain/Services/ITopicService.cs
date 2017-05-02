using System.Collections.Generic;
using Connect.Domain.Abstract;
using Connect.Domain.Models;

namespace Connect.Domain.Services
{
    public interface ITopicService : ICrudService<Topic>
    {
        IEnumerable<Topic> GetSubTopics(int parentTopicId);

        Topic Add(Topic topic);

        IEnumerable<Topic> GetRootTopics();

        IEnumerable<Topic> GetTrendingTopics();
    }
}
