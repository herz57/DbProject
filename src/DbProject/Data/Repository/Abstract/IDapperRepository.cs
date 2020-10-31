using DbProject.Data.Domain;
using DbProject.Infrastructure.Dtos.EntityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.Repository.Abstract
{
    public interface IDapperRepository
    {
        List<OrderDto> GetOrdersWithRelations(int size = 10, int customerId = default);
    }
}
