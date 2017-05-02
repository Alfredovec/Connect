using System;
using System.Collections.Generic;

namespace Connect.Domain.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public DateTimeOffset StartDateTime { get; set; }

        public int Duration { get; set; }

        public string RoomId { get; set; }

        public int TopicId { get; set; }

        public int UserMasterId { get; set; }

        public int UserApprenticeId { get; set; }

        public int LanguageId { get; set; }

        public User UserMaster { get; set; }

        public User UserApprentice { get; set; }

        public Language Language { get; set; }

        public Topic Topic { get; set; }

        public IEnumerable<Rate> Rates { get; set; }
    }
}
