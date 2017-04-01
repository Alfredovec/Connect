using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Api.Models.Display
{
    public class TopicDisplayContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool HasChildren { get; set; }
    }
}