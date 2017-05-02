using System;

namespace Connect.Api.Models.Update
{
    public class LessonUpdateContract
    {
        public int UserMasterId { get; set; }

        public int UserApprenticeId { get; set; }

        public int TopicId { get; set; }
        
        public int LanguageId { get; set; }

        public DateTimeOffset StartDateTime { get; set; }

        public int Duration { get; set; }
    }
}