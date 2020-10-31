using DbProject.Infrastructure.Dtos.EntityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Services.Abstract
{
    public interface IORMPerfomanceTest
    {
        List<OrderDto> GetOrdersWithRelationsAsync(int size = 10, int customerId = default);
    }
}
