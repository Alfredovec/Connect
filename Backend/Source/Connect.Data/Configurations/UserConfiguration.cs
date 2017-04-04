using System.Data.Entity.ModelConfiguration;
using Connect.Data.Entities;

namespace Connect.Data.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("User");
            HasKey(u => u.Id);
            Property(u => u.Name).IsRequired();
        }
    }
}
