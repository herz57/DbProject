using DbProject.Data.Domain;
using DbProject.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.EntityConfigurations
{
    public class CategoryEntityConfiguration : EntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Name);

            builder.Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(c => c.UpdateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();

            builder.Property(c => c.CreateUserId).HasColumnName($"{DefaultTableConvension.GetColumnPrefix(nameof(Category))}_{nameof(OrderStatus.CreateUserId)}");
            builder.Property(c => c.UpdateUserId).HasColumnName($"{DefaultTableConvension.GetColumnPrefix(nameof(Category))}_{nameof(OrderStatus.UpdateUserId)}");

            builder.HasOne(c => c.CreateUser)
               .WithMany(u => u.CreatedCategories)
               .HasForeignKey(c => c.CreateUserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.UpdateUser)
                .WithMany(u => u.UpdatedCategories)
                .HasForeignKey(c => c.UpdateUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
