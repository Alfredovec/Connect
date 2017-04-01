using System.Data.Entity.ModelConfiguration;
using Connect.Data.Entities;

namespace Connect.Data.Configurations
{
    class LessonConfiguration : EntityTypeConfiguration<LessonEntity>
    {
        public LessonConfiguration()
        {
            HasKey(l => l.Id);
        }
    }
}
