using System.Data.Entity.ModelConfiguration;
using Connect.Data.Entities;

namespace Connect.Data.Configurations
{
    class TopicConfiguration : EntityTypeConfiguration<TopicEntity>
    {
        public TopicConfiguration()
        {
            ToTable("Topic");
            HasKey(t => t.Id);
            HasOptional(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(t => t.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
}
