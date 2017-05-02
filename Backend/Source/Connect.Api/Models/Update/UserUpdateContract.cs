
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Connect.Api.Models.Display;

namespace Connect.Api.Models.Update
{
    public class UserUpdateContract
    {
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string AvatarUrl { get; set; }

        public IEnumerable<LanguageSkillUpdateContract> SkillsWished { get; set; }
    }
}