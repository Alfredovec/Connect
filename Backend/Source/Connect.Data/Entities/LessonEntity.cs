using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Data.Entities
{
    [Table("Lesson")]
    public class LessonEntity
    {
        public int Id { get; set; }

        public string Subject { get; set; }
        
        public DateTime Creared { get; set; }
    }
}
