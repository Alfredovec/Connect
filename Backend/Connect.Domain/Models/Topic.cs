using System.Collections.Generic;

namespace Connect.Domain.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Recommended { get; set; }

        public bool Relevant { get; set; }

        public string Url { get; set; }

        public int? ParentId { get; set; }

        public IEnumerable<Topic> Children { get; set; }

        public Topic Parent { get; set; }
    }
}
