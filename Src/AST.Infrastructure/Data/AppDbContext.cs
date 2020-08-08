using AST.Core.Entities;
using AST.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AST.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is BaseEntityAudit && (x.State == EntityState.Added || x.State == EntityState.Modified));

            //var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
            //    ? HttpContext.Current.User.Identity.Name
            //    : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntityAudit)entity.Entity).CreatedAt = DateTime.UtcNow;
                    //((BaseEntityAudit)entity.Entity).CreatedBy = currentUsername;
                }

                ((BaseEntityAudit)entity.Entity).UpdatedAt = DateTime.UtcNow;
                //((BaseEntityAudit)entity.Entity).UpdatedBy = currentUsername;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customizations must go after base.OnModelCreating(builder)
            builder.ApplyConfiguration(new FooConfig());
        }
    }
}
