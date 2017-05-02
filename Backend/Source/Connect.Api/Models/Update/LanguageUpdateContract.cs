using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Api.Models.Update
{
    public class LanguageUpdateContract
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string ImageUrl { get; set; }
    }
}