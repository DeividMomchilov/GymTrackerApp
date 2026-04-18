using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymTrackerApp.Data.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(
            new IdentityUser
            {
                Id = "11111111-2222-3333-4444-555555555555",
                UserName = "admin@gymtracker.com",
                NormalizedUserName = "ADMIN@GYMTRACKER.COM",
                Email = "admin@gymtracker.com",
                NormalizedEmail = "ADMIN@GYMTRACKER.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEPLDGkgokSex9Yy1N5AotosXTKzXUPHYrSNKcQcDYfceG9Ij9w8333qqlMv4UWKvcQ==", // Admin123!
                SecurityStamp = "admin-security-stamp-1234",
                ConcurrencyStamp = "admin-concurrency-stamp-1234"
            },
            new IdentityUser
            {
                Id = "22222222-3333-4444-5555-666666666666",
                UserName = "TestUser123",
                NormalizedUserName = "TESTUSER123",
                Email = "testuser123@gymtracker.com",
                NormalizedEmail = "TESTUSER123@GYMTRACKER.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEPLDGkgokSex9Yy1N5AotosXTKzXUPHYrSNKcQcDYfceG9Ij9w8333qqlMv4UWKvcQ==",
                SecurityStamp = "testuser-security-stamp-1234",
                ConcurrencyStamp = "testuser-concurrency-stamp-1234"
            });
        }
    }
}
