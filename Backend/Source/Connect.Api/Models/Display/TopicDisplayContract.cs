using System.Collections.Generic;
using Connect.Api.Models.Display.Basic;

namespace Connect.Api.Models.Display
{
    public class TopicDisplayContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Recommended { get; set; }

        public bool Relevant { get; set; }

        public string Url { get; set; }

        public TopicBasicDisplayContract Parent { get; set; }

        public IEnumerable<TopicBasicDisplayContract> Children { get; set; }
    }
}