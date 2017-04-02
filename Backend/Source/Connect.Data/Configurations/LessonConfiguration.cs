using System.Data.Entity.ModelConfiguration;
using Connect.Data.Entities;

namespace Connect.Data.Configurations
{
    class LessonConfiguration : EntityTypeConfiguration<LessonEntity>
    {
        public LessonConfiguration()
        {
            ToTable("Lesson");
            HasKey(l => l.Id);
        }
    }
}
