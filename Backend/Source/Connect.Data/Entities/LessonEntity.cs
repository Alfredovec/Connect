using System;
using System.Collections.Generic;

namespace Connect.Data.Entities
{
    public class LessonEntity : BaseEntity
    {
        public int Id { get; set; }

        public DateTimeOffset StartDateTime { get; set; }

        public int Duration { get; set; }

        public int UserMasterId { get; set; }

        public int UserApprenticeId { get; set; }
        
        public int TopicId { get; set; }

        public int LanguageId { get; set; }

        public string RoomId { get; set; }
        
        public virtual UserEntity UserMaster { get; set; }
        
        public virtual UserEntity UserApprentice { get; set; }
        
        public virtual TopicEntity Topic { get; set; }

        public virtual LanguageEntity Language { get; set; }

        public virtual ICollection<RateEntity> Rates { get; set; }
    }
}
