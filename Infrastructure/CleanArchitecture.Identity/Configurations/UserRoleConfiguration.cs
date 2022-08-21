using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "373146bc-6ab2-4d67-a525-b80e320adada",
                    UserId = "9c49ac4e-4bb3-4b85-9cae-1d38b98008ed"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "b9cd9233-d017-4a76-a293-917d1250e8dd",
                    UserId = "25402e5f-92dc-4acf-a4f7-89658352dcd8"
                }
            );
        }
    }
}
