using DbProject.Data.Domain;
using DbProject.Data.Domain.General;
using DbProject.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;

namespace DbProject.Data.DataSeed
{
    public class DataSeed
    {
        public static async Task Seed(AppDbContext context)
        {
            Random rand = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var generatedData = LoadJson("../../../mock_data.json");

            var fullNames = generatedData["full_names"];
            var userNames = generatedData["user_names"];
            var emails = generatedData["emails"];
            var phones = generatedData["phones"];
            var categoryNames = generatedData["category_names"];
            var productNames = generatedData["product_names"];
            var orderStatuses = generatedData["order_statuses"];
            var addresses = generatedData["addresses"];
            var cities = generatedData["cities"];
            var counties = generatedData["counties"];
            var countries = generatedData["countries"];
            var postCodes = generatedData["post_codes"];

            int categoriesCount = categoryNames.Count();
            int productsCount = productNames.Count();
            int orderStatusesCount = orderStatuses.Count();
            int customersCount = 100;
            int orderItemsCount = 1000000;
            int deliveryDetailsCount;
            int invoicesCount;
            int ordersCount = deliveryDetailsCount = invoicesCount = 100000;

            if (await context.Set<User>().AnyAsync())
            {
                var usersList = new List<User> { new User { UserName = "scalverd8", Email = "dlakey3a@storify.com", Phone = "993-420-8239", Mobile = "795-213-5631" } };
                await context.BulkInsertAsync(usersList);
            }

            if (!await context.Set<Category>().AnyAsync())
            {
                var categoryList = new List<Category>();
                var userId = (await context.Set<User>().FirstOrDefaultAsync()).Id;
                for (int i = 0; i < categoriesCount; i++)
                {
                    categoryList.Add(new Category
                    {
                        Name = categoryNames[i].ToString(),
                        CreateUserId = userId,
                        UpdateUserId = userId
                    });
                }

                await context.BulkInsertAsync(categoryList);
            }

            if (!await context.Set<Product>().AnyAsync())
            {
                var productsList = new List<Product>();
                var userId = (await context.Set<User>().FirstOrDefaultAsync()).Id;
                var categoryIds = await context.Set<Category>().Select(x => x.Id).ToListAsync();
                for (int i = 0; i < productsCount; i++)
                {
                    productsList.Add(new Product
                    {
                        Name = productNames[i].ToString(),
                        Price = Math.Round(rand.Next(5, 30) + rand.NextDouble(), 1),
                        CategoryId = categoryIds[rand.Next(categoryIds.Count())],
                        CreateUserId = userId,
                        UpdateUserId = userId
                    });
                }

                await context.BulkInsertAsync(productsList);
            }

            if (!await context.Set<DeliveryDetail>().AnyAsync())
            {
                var deliveryDetailsList = new List<DeliveryDetail>();
                for (int i = 0; i < deliveryDetailsCount; i++)
                {
                    deliveryDetailsList.Add(new DeliveryDetail
                    {
                        Name = fullNames[rand.Next(fullNames.Count())].ToString(),
                        Email = emails[rand.Next(emails.Count())].ToString(),
                        Phone = phones[rand.Next(phones.Count())].ToString(),
                        Mobile = phones[rand.Next(phones.Count())].ToString(),
                        Address = new Address 
                        {
                            Address1 = addresses[rand.Next(addresses.Count())].ToString(),
                            Address2 = addresses[rand.Next(addresses.Count())].ToString(),
                            City = cities[rand.Next(cities.Count())].ToString(),
                            County = counties[rand.Next(counties.Count())].ToString(),
                            Country = countries[rand.Next(countries.Count())].ToString(),
                            PostCode = postCodes[rand.Next(postCodes.Count())].ToString()
                        }
                    });
                }

                await context.BulkInsertAsync(deliveryDetailsList);
            }

            if (!await context.Set<Customer>().AnyAsync())
            {
                var customersList = new List<Customer>();
                var userId = (await context.Set<User>().FirstOrDefaultAsync()).Id;
                for (int i = 0; i < customersCount; i++)
                {
                    customersList.Add(new Customer
                    {
                        Name = fullNames[rand.Next(fullNames.Count())].ToString(),
                        ContactName = fullNames[rand.Next(fullNames.Count())].ToString(),
                        Email = emails[rand.Next(emails.Count())].ToString(),
                        ContactPhone = phones[rand.Next(phones.Count())].ToString(),
                        CreateUserId = userId,
                        UpdateUserId = userId,
                        Address = new Address
                        {
                            Address1 = addresses[rand.Next(addresses.Count())].ToString(),
                            Address2 = addresses[rand.Next(addresses.Count())].ToString(),
                            City = cities[rand.Next(cities.Count())].ToString(),
                            County = counties[rand.Next(counties.Count())].ToString(),
                            Country = countries[rand.Next(countries.Count())].ToString(),
                            PostCode = postCodes[rand.Next(postCodes.Count())].ToString()
                        }
                    });
                }

                await context.BulkInsertAsync(customersList);
            }

            if (!await context.Set<OrderStatus>().AnyAsync())
            {
                var orderStatusesList = new List<OrderStatus>();
                var userId = (await context.Set<User>().FirstOrDefaultAsync()).Id;
                for (int i = 0; i < orderStatusesCount; i++)
                {
                    orderStatusesList.Add(new OrderStatus
                    {
                        Name = orderStatuses[i].ToString(),
                        CreateUserId = userId,
                        UpdateUserId = userId
                    });
                }

                await context.BulkInsertAsync(orderStatusesList);
            }

            if (!await context.Set<Order>().AnyAsync())
            {
                var ordersList = new List<Order>();
                var deliveryDetailIds = await context.Set<DeliveryDetail>().Select(x => x.Id).ToListAsync();
                var customerIds = await context.Set<Customer>().Select(x => x.Id).ToListAsync();
                var orderStatusIds = await context.Set<OrderStatus>().Select(x => x.Id).ToListAsync();
                for (int i = 0; i < ordersCount; i++)
                {
                    ordersList.Add(new Order
                    {
                        DeliveryDetailId = deliveryDetailIds[rand.Next(deliveryDetailIds.Count())],
                        Price = Math.Round(rand.Next(100, 900) + rand.NextDouble(), 1),
                        Currency = (Currency)rand.Next(2),
                        CustomerId = customerIds[rand.Next(customerIds.Count())],
                        OrderStatusId = orderStatusIds[rand.Next(orderStatusIds.Count())],
                    });
                }

                await context.BulkInsertAsync(ordersList);
            }

            if (!await context.Set<Invoice>().AnyAsync())
            {
                var invoicesList = new List<Invoice>();
                var orders = await context.Set<Order>().Select(x => new Order { Id = x.Id, Price = x.Price }).ToListAsync();
                for (int i = 0; i < invoicesCount; i++)
                {
                    var orderId = orders[rand.Next(orders.Count())].Id;
                    invoicesList.Add(new Invoice
                    {
                        OrderId = orderId,
                        PaymentId = i + 1,
                        Price = Math.Round(orders.FirstOrDefault(x => x.Id.Equals(orderId)).Price, 1),
                        NameOnCard = fullNames[rand.Next(fullNames.Count())].ToString(),
                        LastForDigit = rand.Next(1000, 9999).ToString()
                    });
                }

                await context.BulkInsertAsync(invoicesList);
            }

            if (!await context.Set<OrderItem>().AnyAsync())
            {
                var orderItemsList = new List<OrderItem>();
                var ordersIds = await context.Set<Order>().Select(x => x.Id).ToListAsync();
                var productIds = await context.Set<Product>().Select(x => x.Id).ToListAsync();
                for (int i = 0; i < orderItemsCount; i++)
                {
                    orderItemsList.Add(new OrderItem
                    {
                        OrderId = ordersIds[rand.Next(ordersIds.Count())],
                        ProductId = productIds[rand.Next(productIds.Count())],
                        Quantity = rand.Next(1, 3)
                    });
                }

                await context.BulkInsertAsync(orderItemsList);
            }

            Console.WriteLine(string.Format("\nSeeding has finished, time taken: {0}s", Math.Round(stopWatch.Elapsed.TotalSeconds, 1)));
        }

        private static JObject LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string data = r.ReadToEnd();
                return JObject.Parse(data);
            }
        }
    }
}
