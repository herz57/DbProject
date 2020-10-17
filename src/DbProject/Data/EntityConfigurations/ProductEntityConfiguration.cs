using DbProject.Data.Domain;
using DbProject.Helper;
using DbProject.Infrastructure.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.EntityConfigurations
{
    public class ProductEntityConfiguration : EntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Name);
            builder.HasIndex(p => p.Price);

            builder.Property(os => os.CreateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(os => os.UpdateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.CategoryId).HasColumnName(string.Format(
                Consts.StrictForeignKeyName, DefaultTableConvension.GetColumnPrefix(nameof(Product)), DefaultTableConvension.GetColumnPrefix(nameof(Category))));

            builder.Property(p => p.CreateUserId).HasColumnName($"{DefaultTableConvension.GetColumnPrefix(nameof(Product))}_{nameof(OrderStatus.CreateUserId)}");
            builder.Property(p => p.UpdateUserId).HasColumnName($"{DefaultTableConvension.GetColumnPrefix(nameof(Product))}_{nameof(OrderStatus.UpdateUserId)}");

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.CreateUser)
                .WithMany(u => u.CreatedProducts)
                .HasForeignKey(p => p.CreateUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.UpdateUser)
                .WithMany(u => u.UpdatedProducts)
                .HasForeignKey(p => p.UpdateUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
