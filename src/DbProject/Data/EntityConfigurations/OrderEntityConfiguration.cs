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
    public class OrderEntityConfiguration : EntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasIndex(o => o.Price);
            builder.HasIndex(o => o.Currency);

            builder.Property(o => o.CreateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(o => o.UpdateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();

            builder.Property(o => o.CustomerId).HasColumnName(string.Format(
                Consts.StrictForeignKeyName, DefaultTableConvension.GetColumnPrefix(nameof(Order)), DefaultTableConvension.GetColumnPrefix(nameof(Customer))));

            builder.Property(o => o.OrderStatusId).HasColumnName(string.Format(
                Consts.StrictForeignKeyName, DefaultTableConvension.GetColumnPrefix(nameof(Order)), DefaultTableConvension.GetColumnPrefix(nameof(OrderStatus))));
            
            builder.Property(o => o.DeliveryDetailId).HasColumnName(string.Format(
                Consts.StrictForeignKeyName, DefaultTableConvension.GetColumnPrefix(nameof(Order)), DefaultTableConvension.GetColumnPrefix(nameof(DeliveryDetail))));

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.OrderStatus)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.DeliveryDetail)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.DeliveryDetailId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
