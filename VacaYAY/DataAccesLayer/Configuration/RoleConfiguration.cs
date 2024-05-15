using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(

                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "HR",
                    NormalizedName = "HR"
                }
            );
        }
    }
}
