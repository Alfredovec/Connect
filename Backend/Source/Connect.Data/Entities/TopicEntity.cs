using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Connect.Data.Entities
{
    public class TopicEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
        
        public virtual TopicEntity Parent { get; set; }

        public virtual ICollection<TopicEntity> Children { get; set; }
    }
}
