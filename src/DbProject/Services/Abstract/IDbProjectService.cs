using DbProject.Data.Domain;
using DbProject.Infrastructure.Dtos;
using DbProject.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbProject.Services.Abstract
{
    public interface IDbProjectService
    {
        Task<List<CustomerWithOrdersCountDto>> GetCustomersWithOrdersCountsAsync(int page = 1, int size = 10);
        Task<List<OrderWithProductsCountDto>> GetOrderWithProductsCountAsync(int page = 1, int size = 10);
        Task<List<CountDto>> GetCategoriesTotalOrdersCountAsync();
        Task<List<CountDto>> GetTotalPlacedProductsAsync();
        Task<CustomerProductsDto> GetCustomerProductsAsync(int customerId);
        Task<CustomerCategoryProductsDto> GetCustomerCategoryProductsAsync(int customerId);
    }
}
