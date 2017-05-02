using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string AvatarUrl { get; set; }

        public IEnumerable<LanguageSkill> Skills { get; set; }

        public IEnumerable<LanguageSkill> SkillsWished { get; set; }

        public IEnumerable<Rate> IncomingRates { get; set; }

        public IEnumerable<Rate> OutgoingRates { get; set; }
    }
}
