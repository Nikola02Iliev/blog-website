using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id= "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var hasher = new PasswordHasher<AppUser>();
            AppUser adminUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@domain.com",
                NormalizedEmail = "ADMIN@DOMAIN.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "AdminPassword123!");

            builder.Entity<AppUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = "1" 
            });
        }
    }
}
