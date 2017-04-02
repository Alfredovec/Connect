using System.Collections.Generic;

namespace Connect.Api.Models.Display
{
    public class TopicDisplayContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TopicNestedDisplayContract Parent { get; set; }

        public IEnumerable<TopicNestedDisplayContract> Children { get; set; }
    }
}