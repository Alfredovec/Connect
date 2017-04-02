using System.Collections.Generic;

namespace Connect.Domain.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public IEnumerable<Topic> Children { get; set; }

        public Topic Parent { get; set; }
    }
}
