namespace Connect.Data.Entities
{
    public class RateEntity : BaseEntity
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int Value { get; set; }

        public virtual LessonEntity Lesson { get; set; }

        public virtual UserEntity FromUser { get; set; }

        public virtual UserEntity ToUser { get; set; }
    }
}
