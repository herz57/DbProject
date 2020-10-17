using DbProject.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.EntityConfigurations
{
    public class CustomerEntityConfiguration : EntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Name);
            builder.HasIndex(c => c.ContactName);
            builder.HasIndex(c => c.Email);
            builder.HasIndex(c => c.ContactPhone);

            builder.Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
            builder.Property(c => c.UpdateDate).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();

            builder.OwnsOne(
                c => c.Address,
                address =>
                {
                    address.HasIndex(c => c.Address1);
                    address.HasIndex(c => c.Address2);
                    address.HasIndex(c => c.City);
                    address.HasIndex(c => c.County);
                    address.HasIndex(c => c.Country);
                    address.HasIndex(c => c.PostCode);
                });

            builder.HasOne(c => c.CreateUser)
                .WithMany(u => u.CreatedCustomers)
                .HasForeignKey(c => c.CreateUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.UpdateUser)
                .WithMany(u => u.UpdatedCustomers)
                .HasForeignKey(c => c.UpdateUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
