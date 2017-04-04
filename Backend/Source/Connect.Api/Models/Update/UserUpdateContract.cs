
using System.ComponentModel.DataAnnotations;

namespace Connect.Api.Models.Update
{
    public class UserUpdateContract
    {
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}