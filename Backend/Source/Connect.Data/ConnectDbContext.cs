using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Connect.Data.Configurations;
using Connect.Data.Entities;

namespace Connect.Data
{
    public class ConnectDbContext : DbContext
    {
        public ConnectDbContext() : base(ConnectionString)
        {
        }

        // public DbSet<LessonEntity> Lessons { get; set; }

        public DbSet<TopicEntity> Topics { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new LessonConfiguration());
            //modelBuilder.Configurations.Add(new RateConfiguration());
            modelBuilder.Configurations.Add(new TopicConfiguration());
            //modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            SetTimestamps();
            return await base.SaveChangesAsync();
        }

        private const string ConnectionString =
            "Server=tcp:connectlangdb.database.windows.net,1433;" +
            "Initial Catalog=connectdb;" +
            "Persist Security Info=False;" +
            "User ID=SergiiRud;" +
            "Password=Password1!;" +
            "MultipleActiveResultSets=False;" +
            "Encrypt=True;" +
            "TrustServerCertificate=False;" +
            "Connection Timeout=30;";

        private void SetTimestamps()
        {
            var entities = ChangeTracker
                    .Entries()
                    .Where(x => x.Entity is BaseEntity && 
                        (x.State == EntityState.Added || x.State == EntityState.Modified));
            
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                    ((BaseEntity)entity.Entity).Created = DateTimeOffset.UtcNow;

                ((BaseEntity)entity.Entity).Modified = DateTimeOffset.UtcNow;
            }
        }
    }
}
