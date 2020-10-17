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
    public class OrderStatusEntityConfiguration : EntityTypeConfiguration<OrderStatus>
    {
        public override void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.Id);

            builder.HasIndex(os => os.Name);

            builder.Property(os => os.CreateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(os => os.UpdateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();

            builder.Property(os => os.CreateUserId).HasColumnName($"{DefaultTableConvension.GetColumnPrefix(nameof(OrderStatus))}_{nameof(OrderStatus.CreateUserId)}");
            builder.Property(os => os.UpdateUserId).HasColumnName($"{DefaultTableConvension.GetColumnPrefix(nameof(OrderStatus))}_{nameof(OrderStatus.UpdateUserId)}");

            builder.HasOne(os => os.CreateUser)
                .WithMany(u => u.CreatedOrderStatuses)
                .HasForeignKey(os => os.CreateUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(os => os.UpdateUser)
                .WithMany(u => u.UpdatedOrderStatuses)
                .HasForeignKey(os => os.UpdateUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
