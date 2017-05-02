namespace Connect.Data.Entities
{
    public class LanguageSkillEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public int LanguageId { get; set; }

        public int? UserId { get; set; }
        
        public int? UserWishedId { get; set; }

        public virtual LanguageEntity Language { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual UserEntity UserWished { get; set; }
    }
}
