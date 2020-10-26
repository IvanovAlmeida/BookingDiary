using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BD.Data.Mappings
{
    public class UsersWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        private const int adminUserId = 1;
        private const int adminRoleId = 1;

        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            IdentityUserRole<int> iur = new IdentityUserRole<int>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            };

            builder.HasData(iur);
            builder.HasKey(p => new { p.RoleId, p.UserId });

            builder.ToTable("UsersRoles");
        }
    }
}
