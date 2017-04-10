using System.Collections.Generic;
using Connect.Api.Models.Display.Basic;

namespace Connect.Api.Models.Display
{
    public class UserDisplayContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string AvatarUrl { get; set; }

        public IEnumerable<LanguageSkillBasicDisplayContract> Languages { get; set; }
    }
}