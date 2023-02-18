﻿using Medicine.Domain;
using Medicine.Domain.Enums;
using Medicine.Infrastructure.Persistence;
using Medicine.Shared;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Data
{
    public class DatabaseMigrator
    {
        private readonly AppDbContext appDbContext;

        public DatabaseMigrator(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task MigrateAsync()
        {
            await appDbContext.Database.MigrateAsync();

            var user = appDbContext.Set<User>().Where(p => p.Name.Equals("Administrator"));
            if (!user.Any())
            {
                var role = new Role
                {
                    Name = "Administrator",
                    Permissions = new List<Permission>
                {
                    new Permission {ClaimType=ClaimType.Role, ClaimValue=ClaimValue.FullAccess },
                    new Permission {ClaimType=ClaimType.RolePremission, ClaimValue=ClaimValue.FullAccess  } ,
                    new Permission { ClaimType = ClaimType.User, ClaimValue = ClaimValue.FullAccess }
                }

                };
                var newUser = new User
                {
                    Name = "Administrator",
                    Role = role,
                    Password = StringHelper.GetMd5Sum("12345678")
                };
                await appDbContext.Set<User>().AddAsync(newUser);
                await appDbContext.SaveChangesAsync();
            }

        }
    }
}
