using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Infra.Data.Map;

namespace SimpleBlog.Infra.Data.Context
{
    public class SimpleBlogConext : DbContext
    {
        public SimpleBlogConext(DbContextOptions<SimpleBlogConext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapUsers());
            modelBuilder.ApplyConfiguration(new MapPosts());
        }



        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("InclusionDate").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State != EntityState.Modified) continue;
                entry.Property("ChangeDate").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
