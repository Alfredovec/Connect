namespace Connect.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string AvatarUrl { get; set; }
    }
}
