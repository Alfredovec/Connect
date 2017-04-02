using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Domain.Models
{
    public class Rate
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int Value { get; set; }
    }
}
