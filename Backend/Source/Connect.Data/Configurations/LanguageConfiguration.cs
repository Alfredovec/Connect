using System.Data.Entity.ModelConfiguration;
using Connect.Data.Entities;

namespace Connect.Data.Configurations
{
    class LanguageConfiguration : EntityTypeConfiguration<LanguageEntity>
    {
        public LanguageConfiguration()
        {
            ToTable("Language");
            HasKey(l => l.Id);
            Property(l => l.Name).IsRequired();
        }
    }
}
