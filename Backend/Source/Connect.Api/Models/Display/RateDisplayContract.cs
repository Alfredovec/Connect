using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Api.Models.Display
{
    public class RateDisplayContract
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int Value { get; set; }
    }
}