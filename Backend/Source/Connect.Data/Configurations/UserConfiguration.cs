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

            HasMany(a => a.Friends)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("LeftUserId");
                    x.MapRightKey("RightUserId");
                    x.ToTable("Friends");
                });
        }
    }
}
