using DbProject.Data.Repository.Abstract;
using DbProject.Infrastructure.Dtos;
using DbProject.Infrastructure.Dtos.EntityDtos;
using DbProject.Services.Abstract;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbProject.Services
{
    public class NHibernatePerfomanceTest : IORMPerfomanceTest
    {
        private readonly IMapperSession<OrderDto> _NHibernateOrderRepository;

        public NHibernatePerfomanceTest(IMapperSession<OrderDto> NHibernateOrderRepository)
        {
            _NHibernateOrderRepository = NHibernateOrderRepository;
        }

        public List<OrderDto> GetOrdersWithRelationsAsync(int size = 10, int customerId = default)
        {
            var table = _NHibernateOrderRepository.Session.Query<OrderDto>();

            if (customerId != default)
            {
                table = table.Where(x => x.CustomerId == customerId);
            }

            return table
                .Where(x => x.Id <= size)
                .OrderBy(x => x.Id)
                .Fetch(x => x.Customer)
                .Fetch(x => x.OrderStatus)
                .Fetch(x => x.OrderItems)
                .ToList();
        }
    }
}
