using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Api.Models.Update
{
    public class LanguageSkillUpdateContract
    {
        public string Level { get; set; }

        public int LanguageId { get; set; }
    }
}