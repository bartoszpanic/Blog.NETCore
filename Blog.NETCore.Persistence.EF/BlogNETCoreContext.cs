using Blog.NETCore.Domain.Entities;
using Blog.NETCore.Persistence.EF.DummyData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.NETCore.Persistence.EF
{
    public class BlogNETCoreContext : DbContext
    {
        public BlogNETCoreContext(DbContextOptions<BlogNETCoreContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfigurationsFromAssembly
                (typeof(BlogNETCoreContext).Assembly);

            foreach (var item in DummyComment.GetComments())
            {
                modelBuilder.Entity<Comment>().HasData(item);
            }

            foreach (var item in DummyPost.GetPosts())
            {
                modelBuilder.Entity<Post>().HasData(item);
            }
        }
    }
}
