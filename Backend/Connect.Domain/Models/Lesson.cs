using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Domain.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public DateTime Creared { get; set; }
    }
}
