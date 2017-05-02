using System.Collections.Generic;

namespace Connect.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string AvatarUrl { get; set; }

        public virtual ICollection<UserEntity> Friends { get; set; }

        public virtual ICollection<LanguageSkillEntity> Skills { get; set; }
        
        public virtual ICollection<LanguageSkillEntity> SkillsWished { get; set; }

        public virtual ICollection<RateEntity> IncomingRates { get; set; }

        public virtual ICollection<RateEntity> OutgoingRates { get; set; }
    }
}
