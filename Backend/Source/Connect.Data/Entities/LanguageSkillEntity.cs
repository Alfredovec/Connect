using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Data.Entities
{
    public class LanguageSkillEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public int LanguageId { get; set; }

        public int UserId { get; set; }

        public virtual LanguageEntity Language { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
