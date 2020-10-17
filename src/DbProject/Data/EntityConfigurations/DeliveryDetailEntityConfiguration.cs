using DbProject.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.EntityConfigurations
{
    public class DeliveryDetailEntityConfiguration : EntityTypeConfiguration<DeliveryDetail>
    {
        public override void Configure(EntityTypeBuilder<DeliveryDetail> builder)
        {
            builder.HasKey(dd => dd.Id);

            builder.HasIndex(dd => dd.Name);
            builder.HasIndex(dd => dd.Email);
            builder.HasIndex(dd => dd.Phone);
            builder.HasIndex(dd => dd.Mobile);

            builder.OwnsOne(
                dd => dd.Address,
                address =>
                {
                    address.HasIndex(dd => dd.Address1);
                    address.HasIndex(dd => dd.Address2);
                    address.HasIndex(dd => dd.City);
                    address.HasIndex(dd => dd.County);
                    address.HasIndex(dd => dd.Country);
                    address.HasIndex(dd => dd.PostCode);
                });

            builder.Property(dd => dd.CreateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(dd => dd.UpdateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();
        }
    }
}
