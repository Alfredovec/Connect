using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Connect.Api.Models.Update
{
    public class TopicUpdateContract
    {
        [Required]
        public string Name { get; set; }
        
        public string ParentName { get; set; }
    }
}