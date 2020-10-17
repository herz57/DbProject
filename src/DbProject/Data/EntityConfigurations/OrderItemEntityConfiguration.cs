using DbProject.Data.Domain;
using DbProject.Helper;
using DbProject.Infrastructure.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbProject.Data.EntityConfigurations
{
    public class OrderItemEntityConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.HasIndex(oi => oi.Quantity);

            builder.Property(oi => oi.CreateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(oi => oi.UpdateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();

            builder.Property(o => o.OrderId).HasColumnName(string.Format(
                Consts.StrictForeignKeyName, DefaultTableConvension.GetColumnPrefix(nameof(OrderItem)), DefaultTableConvension.GetColumnPrefix(nameof(Order))));

            builder.Property(o => o.ProductId).HasColumnName(string.Format(
                Consts.StrictForeignKeyName, DefaultTableConvension.GetColumnPrefix(nameof(OrderItem)), DefaultTableConvension.GetColumnPrefix(nameof(Product))));

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.Product)
               .WithMany(p => p.OrderItems)
               .HasForeignKey(oi => oi.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
