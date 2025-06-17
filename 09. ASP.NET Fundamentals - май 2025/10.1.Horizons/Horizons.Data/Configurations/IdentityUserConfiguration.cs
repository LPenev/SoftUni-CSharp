﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizons.Data.Configurations;

public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        //builder
        //    .HasData(this.CreateDefaultUser);
    }

    private IdentityUser CreateDefaultUser()
    {
        IdentityUser defaultUser = new IdentityUser
        {
            Id = "7699db7d-964f-4782-8209-d76562e0fece",
            UserName = "admin@horizons.com",
            NormalizedUserName = "ADMIN@HORIZONS.COM",
            Email = "admin@horizons.com",
            NormalizedEmail = "ADMIN@HORIZONS.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                new IdentityUser { UserName = "admin@horizons.com" },
                "Admin123!")
        };

        return defaultUser;
    }
}
