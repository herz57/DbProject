using DbProject.Data.Repository;
using DbProject.Infrastructure.Dtos.EntityDtos;
using DbProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Services
{
    public class DapperPerfomanceTest : IORMPerfomanceTest
    {
        private readonly DapperRepository _dapperRepository;

        public DapperPerfomanceTest(DapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public List<OrderDto> GetOrdersWithRelationsAsync(int size = 10, int customerId = default)
        {
            return _dapperRepository.GetOrdersWithRelations(size, customerId);
        }
    }
}
