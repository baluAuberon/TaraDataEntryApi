using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TARA.DATAENTRY.API.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
             var readerRoleId = "95e3cab0-feb5-4bfa-ab00-700f9176ea1b";
            var writerRoleID = "6649899a-3c06-4774-9e31-f5c98c5641c2";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                 
                    ConcurrencyStamp=readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                 new IdentityRole
                {
                   
                    ConcurrencyStamp=writerRoleID,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };
            builder.HasData(roles);
        }
    }
}
