using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Blog.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<BlogUser>
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Fluent API configurations
            modelBuilder.Entity<Post>(
                p=>
                {
                    p.Property(p => p.CreatedBy).HasMaxLength(200);
                    p.Property(p => p.Title).HasMaxLength(200);
                    p.Ignore(p => p.User);

                });     

        }

    }
}