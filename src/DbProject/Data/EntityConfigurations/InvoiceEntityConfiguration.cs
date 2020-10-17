using DbProject.Data.Domain;
using DbProject.Helper;
using DbProject.Infrastructure.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbProject.Data.EntityConfigurations
{
    public class InvoiceEntityConfiguration : EntityTypeConfiguration<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasIndex(i => i.PaymentId);
            builder.HasIndex(i => i.Price);
            builder.HasIndex(i => i.NameOnCard);
            builder.HasIndex(i => i.LastForDigit);

            builder.Property(i => i.CreateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(i => i.UpdateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();

            builder.Property(i => i.OrderId).HasColumnName(string.Format(
                Consts.StrictForeignKeyName, DefaultTableConvension.GetColumnPrefix(nameof(Invoice)), DefaultTableConvension.GetColumnPrefix(nameof(Order))));

            builder.HasOne(i => i.Order)
                .WithMany(u => u.Invoices)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
