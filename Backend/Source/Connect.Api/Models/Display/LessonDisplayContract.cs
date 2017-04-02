using System;
using Newtonsoft.Json;

namespace Connect.Api.Models.Display
{
    public class LessonDisplayContract
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public DateTimeOffset Creared { get; set; }
    }
}