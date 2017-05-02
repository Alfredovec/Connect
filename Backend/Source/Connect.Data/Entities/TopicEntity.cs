using System.Collections.Generic;

namespace Connect.Data.Entities
{
    public class TopicEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SourceUrl { get; set; }

        public string ImageUrl { get; set; }

        public bool Recommended { get; set; }

        public bool Relevant { get; set; }

        public int? ParentId { get; set; }
        
        public virtual TopicEntity Parent { get; set; }

        public virtual ICollection<TopicEntity> Children { get; set; }
    }
}
