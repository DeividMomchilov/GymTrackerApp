using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.Data.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "11111111-2222-3333-4444-555555555555",
                    RoleId = "1"
                },
                new IdentityUserRole<string>
                {
                    UserId = "22222222-3333-4444-5555-666666666666",
                    RoleId = "2"
                }
            );
        }
    }
}
