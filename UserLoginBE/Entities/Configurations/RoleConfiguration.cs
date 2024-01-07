using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserLoginBE.Common;

namespace UserLoginBE.Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            RoleConstant.ListRoles.Select(x => new IdentityRole()
            {
                Name = x,
                NormalizedName = x,
            }));
        }
    }
}
