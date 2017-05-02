namespace Connect.Data.Entities
{
    public class LanguageEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string ImageUrl { get; set; }

        public decimal Complexity { get; set; }
    }
}
