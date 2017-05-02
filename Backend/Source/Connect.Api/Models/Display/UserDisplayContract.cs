using System.Collections.Generic;

namespace Connect.Api.Models.Display
{
    public class UserDisplayContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string AvatarUrl { get; set; }

        public IEnumerable<LanguageSkillDisplayContract> Skills { get; set; }

        public IEnumerable<LanguageSkillDisplayContract> SkillsWished { get; set; }
    }
}