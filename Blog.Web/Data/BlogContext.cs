using Blog.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Blog.Data
{
    public class ApplicationDbContext : IdentityDbContext<BlogUser>
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
             modelBuilder.ApplyConfiguration(new AdminConfiguration());
            //Fluent API configurations
            //modelBuilder.Entity<Post>(
            //    p =>
            //    {
            //        p.HasKey(x => x.Id);
            //        p.Property(p => p.AuthorId).HasMaxLength(200);
            //        p.Property(p => p.Title).HasMaxLength(200);
            //        p.Ignore(p => p.Author);


            //    });
        }

           
        public class AdminConfiguration : IEntityTypeConfiguration<BlogUser>
        {
            private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

            public void Configure(EntityTypeBuilder<BlogUser> builder)
            {
              
                var admin = new BlogUser
                {
                    Id = adminId,
                    UserName = "Admin@Admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    FullName =  "Admin",
                    Email = "Admin@Admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    ConcurrencyStamp= new Guid().ToString("D"),
                    PhoneNumber = "XXXXXXXXXXXXX",
                    EmailConfirmed = true,
                    LockoutEnabled=false,   
                    AccessFailedCount=5,                        
                    PhoneNumberConfirmed = true,
                    DateRegistered= DateTime.Now,
                    SecurityStamp = new Guid().ToString("D"),
                    TwoFactorEnabled=false,                    
                };

                admin.PasswordHash = PassGenerate(admin);

                builder.HasData(admin);
            }

            public string PassGenerate(BlogUser user)
            {
                var passHash = new PasswordHasher<BlogUser>();
                return passHash.HashPassword(user, "password");
            }
        }

    }
}