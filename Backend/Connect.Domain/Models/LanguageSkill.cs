using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Domain.Models
{
    public class LanguageSkill
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public int LanguageId { get; set; }

        public int UserId { get; set; }

        public virtual Language Language { get; set; }

        public virtual User User { get; set; }
    }
}
