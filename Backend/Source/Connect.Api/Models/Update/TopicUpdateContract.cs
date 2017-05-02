using System.ComponentModel.DataAnnotations;

namespace Connect.Api.Models.Update
{
    public class TopicUpdateContract
    {
        [Required]
        public string Name { get; set; }
        
        public int? ParentId { get; set; }

        public bool Recommended { get; set; }

        public string SourceUrl { get; set; }

        public string ImageUrl { get; set; }
    }
}