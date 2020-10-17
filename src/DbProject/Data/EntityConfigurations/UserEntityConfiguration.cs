using DbProject.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbProject.Data.EntityConfigurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.UserName);
            builder.HasIndex(u => u.Email);
            builder.HasIndex(u => u.Phone);
            builder.HasIndex(u => u.Mobile);
        }
    }
}

