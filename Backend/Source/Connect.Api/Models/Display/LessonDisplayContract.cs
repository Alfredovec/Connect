using System;
using Connect.Api.Models.Display.Basic;

namespace Connect.Api.Models.Display
{
    public class LessonDisplayContract
    {
        public int Id { get; set; }

        public string Language { get; set; }

        public string RoomId { get; set; }

        public DateTimeOffset StartDateTime { get; set; }

        public int Duration { get; set; }

        public TopicBasicDisplayContract Topic { get; set; }

        public UserBasicDisplayContract UserMaster { get; set; }

        public UserBasicDisplayContract UserApprentice { get; set; }
    }
}