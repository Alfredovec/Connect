using System.ComponentModel.DataAnnotations.Schema;

namespace Connect.Data.Entities
{
    public class LessonEntity : BaseEntity
    {
        public int Id { get; set; }

        // public int UserMasterId { get; set; }

        public int UserApprenticeId { get; set; }

        public int TopicId { get; set; }

        [ForeignKey("UserMasterId")]
        public virtual UserEntity UserMaster { get; set; }

        [ForeignKey("UserApprenticeId")]
        public virtual UserEntity UserApprentice { get; set; }

        [ForeignKey("TopicId")]
        public virtual TopicEntity Topic { get; set; }
    }
}
