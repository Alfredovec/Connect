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
            Property(l => l.StartDateTime).IsRequired();
            Property(l => l.Duration).IsRequired();

            HasRequired(l => l.UserApprentice)
                .WithMany()
                .HasForeignKey(l => l.UserApprenticeId)
                .WillCascadeOnDelete(false);

            HasRequired(l => l.UserMaster)
                .WithMany()
                .HasForeignKey(l => l.UserMasterId)
                .WillCascadeOnDelete(false);

            HasRequired(l => l.Topic)
                .WithMany()
                .HasForeignKey(l => l.TopicId)
                .WillCascadeOnDelete(false);

            HasRequired(l => l.Language)
                .WithMany()
                .HasForeignKey(l => l.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}
