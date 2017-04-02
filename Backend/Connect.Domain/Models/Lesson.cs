using System;

namespace Connect.Domain.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public int UserMasterId { get; set; }

        public int UserApprenticeId { get; set; }

        public int SubjectId { get; set; }

        public DateTimeOffset Created { get; set; }
    }
}
