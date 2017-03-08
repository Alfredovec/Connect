using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;
using Connect.Data.Configurations;
using Connect.Data.Entities;

namespace Connect.Data
{
    public class ConnectDbContext : DbContext
    {
        public ConnectDbContext() : base(ConnectionString) { }

        public DbSet<LessonEntity> Lessons { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LessonConfiguration());

            base.OnModelCreating(modelBuilder);
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
    }
}
