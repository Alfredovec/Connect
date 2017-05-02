namespace Connect.Api.Models.Display.Basic
{
    public class TopicBasicDisplayContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Recommended { get; set; }

        public bool Relevant { get; set; }

        public string SourceUrl { get; set; }

        public string ImageUrl { get; set; }
    }
}