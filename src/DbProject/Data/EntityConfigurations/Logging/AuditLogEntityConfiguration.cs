using DbProject.Data.Domain;
using DbProject.Data.Domain.Logging;
using DbProject.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.EntityConfigurations
{
    public class AuditLogEntityConfiguration : EntityTypeConfiguration<AuditLog>
    {
        public override void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(al => al.Id);

            builder.HasIndex(al => al.TableName);
            builder.HasIndex(al => al.Action);

            builder.Property(al => al.CreateDate).HasComputedColumnSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(al => al.UpdateDate).HasComputedColumnSql("getutcdate()").ValueGeneratedOnUpdate();

            builder.Property(al => al.CreateUserId).HasColumnName($"{DefaultTableConvension.GetColumnPrefix(nameof(AuditLog))}_{nameof(OrderStatus.CreateUserId)}");
            builder.Property(al => al.UpdateUserId).HasColumnName($"{DefaultTableConvension.GetColumnPrefix(nameof(AuditLog))}_{nameof(OrderStatus.UpdateUserId)}");

            builder.HasOne(al => al.CreateUser)
                .WithMany(u => u.CreatedAuditLogs)
                .HasForeignKey(al => al.CreateUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(al => al.UpdateUser)
                .WithMany(u => u.UpdatedAuditLogs)
                .HasForeignKey(al => al.UpdateUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
