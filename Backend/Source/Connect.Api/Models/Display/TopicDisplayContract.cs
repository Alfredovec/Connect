using System.Collections.Generic;

namespace Connect.Api.Models.Display
{
    public class TopicDisplayContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TopicBasicDisplayContract Parent { get; set; }

        public IEnumerable<TopicBasicDisplayContract> Children { get; set; }
    }
}