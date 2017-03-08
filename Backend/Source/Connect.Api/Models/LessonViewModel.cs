using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Connect.Api.Models
{
    public class LessonViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Subject { get; set; }

        public DateTime Creared { get; set; }
    }
}