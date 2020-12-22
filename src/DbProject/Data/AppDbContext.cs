using DbProject.Data.Domain.General;
using DbProject.Data.EntityConfigurations;
using DbProject.Helper;
using DbProject.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DbProject.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;

        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<EncryptionOptions> encryptionOptions = null)
            : base(options)
        {
            byte[] key = Convert.FromBase64String(encryptionOptions.Value.Key);
            byte[] iv = Convert.FromBase64String(encryptionOptions.Value.IV);
            _provider = new AesProvider(key, iv);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));

            modelBuilder.Owned<Address>();

            foreach (var typeConfiguration in typeConfigurations)
            {
                dynamic configuration = Activator.CreateInstance(typeConfiguration);
                modelBuilder.ApplyConfiguration(configuration);
            }

            //todo: have you checked something like this?
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());

            SetNames(modelBuilder);
            modelBuilder.UseEncryption(_provider);
            base.OnModelCreating(modelBuilder);
        }

        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        private void SetNames(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().Reverse())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (!property.IsForeignKey()) 
                        //todo: will it work for foreign keys? Instead of writing it for each configuration separately
                    {
                        property.SetColumnName(
                            string.Format("{0}_{1}",
                                DefaultTableConvension.GetColumnPrefix(entityType.GetTableName()),
                                property.GetColumnName())
                            );
                    }
                }

                if (!entityType.IsOwned())
                {
                    entityType.SetTableName($"tbl{entityType.GetTableName()}");
                }
            }
        }
    }
}
