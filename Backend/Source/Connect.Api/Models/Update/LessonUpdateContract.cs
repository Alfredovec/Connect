using System;

namespace Connect.Api.Models.Update
{
    public class LessonUpdateContract
    {
        public int UserMasterId { get; set; }

        public int UserApprenticeId { get; set; }

        public int SubjectId { get; set; }
    }
}