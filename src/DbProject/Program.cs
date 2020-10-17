using AutoMapper;
using DbProject.Data;
using DbProject.Data.DataSeed;
using DbProject.Data.UnitOfWork;
using DbProject.Infrastructure.Mappings;
using DbProject.Infrastructure.Options;
using DbProject.Services;
using DbProject.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DbProject
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();

            var connString = builder.GetConnectionString("AppConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(connString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }

    class Program
    {
        public static IConfigurationRoot _configuration;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var dbProjectService = serviceProvider.GetRequiredService<IDbProjectService>();
            

            while (true)
            {
                Console.WriteLine(@"
                    Options:
                        a: Functionality
                        b: ORM perfomanse testing
                ");

                Stopwatch stopWatch = new Stopwatch();
                double queryTime = default;
                object result = null;
                int size;

                Console.Write("\nenter option: ");
                string option = Console.ReadLine();
                Console.WriteLine();

                if (option == "a")
                {
                    int customerId;
                    Console.WriteLine(@"
                    Options:
                        a: Get customers with orders counts
                        b: Get order with products count
                        c: Get customer products
                        d: Get customer category products
                        e: Get categories total orders count
                        f: Get total placed products
                    ");

                    Console.Write("\nenter option: ");
                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "a":
                            Console.Write("enter size: ");
                            size = int.Parse(Console.ReadLine());
                            stopWatch.Start();
                            result = dbProjectService.GetCustomersWithOrdersCountsAsync(size: size).Result;
                            queryTime = Math.Round(stopWatch.Elapsed.TotalMilliseconds);
                            break;
                        case "b":
                            Console.Write("enter size: ");
                            size = int.Parse(Console.ReadLine());
                            stopWatch.Start();
                            result = dbProjectService.GetOrderWithProductsCountAsync(size: size).Result;
                            queryTime = Math.Round(stopWatch.Elapsed.TotalMilliseconds);
                            break;
                        case "c":
                            Console.Write("enter customer id: ");
                            customerId = int.Parse(Console.ReadLine());
                            stopWatch.Start();
                            result = dbProjectService.GetCustomerProductsAsync(customerId).Result;
                            queryTime = Math.Round(stopWatch.Elapsed.TotalMilliseconds);
                            break;
                        case "d":
                            Console.Write("enter customer id: ");
                            customerId = int.Parse(Console.ReadLine());
                            stopWatch.Start();
                            result = dbProjectService.GetCustomerCategoryProductsAsync(customerId).Result;
                            queryTime = Math.Round(stopWatch.Elapsed.TotalMilliseconds);
                            break;
                        case "e":
                            stopWatch.Start();
                            result = dbProjectService.GetCategoriesTotalOrdersCountAsync().Result;
                            queryTime = Math.Round(stopWatch.Elapsed.TotalMilliseconds);
                            break;
                        case "f":
                            stopWatch.Start();
                            result = dbProjectService.GetTotalPlacedProductsAsync().Result;
                            queryTime = Math.Round(stopWatch.Elapsed.TotalMilliseconds);
                            break;
                    }
                    ShowObjectResult(result);
                }
                else if (option == "b")
                {

                    Console.Write("Getting orders with relations\nenter size: ");
                    size = int.Parse(Console.ReadLine());
                    stopWatch.Start();
                    result = dbProjectService.GetOrdersWithRelations(size: size).Result;
                    queryTime = Math.Round(stopWatch.Elapsed.TotalMilliseconds);
                }

                Console.WriteLine(string.Format("Request time taken: {0}ms", queryTime));
            }
        }

        private static void ShowObjectResult(object obj)
        {
            if (obj is IList objList)
            {
                foreach (object item in objList)
                {
                    ShowObjectResult(item);
                }
            }
            else
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                {
                    object value = descriptor.GetValue(obj);
                    if (value is null)
                    {
                        continue;
                    }
                    else if (value is IList list)
                    {
                        foreach (object item in list)
                        {
                            ShowObjectResult(item);
                        }
                    }
                    else if (value.GetType() != typeof(string) && value.GetType().IsClass)
                    {
                        ShowObjectResult(value);
                    }
                    else
                    {
                        string name = descriptor.Name;
                        Console.WriteLine("{0}: {1}", name, value);
                        if (descriptor == TypeDescriptor.GetProperties(obj)[^1])
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = _configuration.GetConnectionString("AppConnection");
            services.AddDbContext<AppDbContext>(options =>
                options
                    .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
                    .UseSqlServer(connectionString, b => b.MigrationsAssembly("DbProject"))) ;

            services.Configure<EncryptionOptions>(_configuration.GetSection(EncryptionOptions.Encryption));
            services.AddAutoMapper(typeof(MappingProfile).GetTypeInfo().Assembly);
            services.AddTransient<AppDbContext, AppDbContext>();
            services.AddTransient<UnitOfWork, UnitOfWork>();
            services.AddTransient<IDbProjectService, DbProjectService>();

            using (var serviceScope = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
                {
                    context.Database.Migrate();
                    DataSeed.Seed(context).Wait();
                }
            }
        }
    }
}
