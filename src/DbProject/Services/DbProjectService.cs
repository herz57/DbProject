using DbProject.Data.Repository;
using DbProject.Services.Abstract;
using DbProject.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DbProject.Data.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DbProject.Infrastructure.Enums;
using DbProject.Infrastructure.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DbProject.Infrastructure.Dtos;

namespace DbProject.Services
{
    public class DbProjectService : IDbProjectService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DbProjectService(UnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CustomerWithOrdersCountDto>> GetCustomersWithOrdersCountsAsync(int page = 1, int size = 10)
        {
            return await _unitOfWork.CustomerRepository.TableNoTracking
               .ProjectTo<CustomerWithOrdersCountDto>(_mapper.ConfigurationProvider)
               .Skip((page - 1) * size)
               .Take(size)
               .ToListAsync();
        }

        public async Task<List<OrderWithProductsCountDto>> GetOrderWithProductsCountAsync(int page = 1, int size = 10)
        {

            return await _unitOfWork.OrderRepository.TableNoTracking
                .Skip((page - 1) * size)
                .Take(size)
                .Include(o => o.DeliveryDetail)
                .ProjectTo<OrderWithProductsCountDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<CountDto>> GetCategoriesTotalOrdersCountAsync()
        {
            return await _unitOfWork.CategoryRepository.TableNoTracking
                .Select(x => new CountDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = _unitOfWork.OrderItemRepository.TableNoTracking
                        .Where(oi => oi.Product.CategoryId == x.Id)
                        .Select(c => c.OrderId)
                        .Distinct()
                        .Count()
                })
                .ToListAsync();
        }

        public async Task<List<CountDto>> GetTotalPlacedProductsAsync()
        {
            return await _unitOfWork.OrderItemRepository.TableNoTracking
                    .Where(x => x.Order.OrderStatusId == (int)OrderStatusEn.Placed)
                    .GroupBy(x => new { x.ProductId, x.Product.Name }).Select(x => new CountDto { Id = x.Key.ProductId, Name = x.Key.Name, Count = x.Sum(y => y.Quantity) })
                    .ToListAsync();
        }

        public async Task<CustomerProductsDto> GetCustomerProductsAsync(int customerId)
        {
            return new CustomerProductsDto
            {
                Name = await _unitOfWork.CustomerRepository.TableNoTracking.Where(x => x.Id == customerId).Select(x => x.Name).FirstOrDefaultAsync(),
                Products = await _unitOfWork.OrderItemRepository.TableNoTracking
                    .Where(x => x.Order.CustomerId == customerId)
                    .GroupBy(x => new { x.ProductId, x.Product.Name }).Select(x => new CountDto { Id = x.Key.ProductId, Name = x.Key.Name, Count = x.Sum(y => y.Quantity) })
                    .ToListAsync()
            };
        }

        public async Task<CustomerCategoryProductsDto> GetCustomerCategoryProductsAsync(int customerId)
        {
            return new CustomerCategoryProductsDto
            {
                Name = await _unitOfWork.CustomerRepository.TableNoTracking.Where(x => x.Id == customerId).Select(x => x.Name).FirstOrDefaultAsync(),
                CategoryProducts = await _unitOfWork.OrderItemRepository.TableNoTracking
                    .Where(x => x.Order.CustomerId == customerId)
                    .GroupBy(x => new { x.Product.CategoryId, x.Product.Category.Name }).Select(x => new CountDto { Id = x.Key.CategoryId, Name = x.Key.Name, Count = x.Sum(y => y.Quantity) })
                    .ToListAsync()
            };
        }

        // perfomanse testing
        public async Task<List<Order>> GetOrdersWithRelations(int size = 10)
        {
            return await _unitOfWork.OrderRepository.TableNoTracking
                .Include(x => x.Customer)
                .Include(x => x.DeliveryDetail)
                .Include(x => x.Invoices)
                .Include(x => x.OrderStatus)
                .Include(x => x.OrderItems)
                .Take(size)
                .ToListAsync();
        }
    }
}
