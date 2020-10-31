using AutoMapper;
using AutoMapper.QueryableExtensions;
using DbProject.Data.UnitOfWork;
using DbProject.Infrastructure.Dtos.EntityDtos;
using DbProject.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Services
{
    public class EntityFrameworkPerfomanceTest : IORMPerfomanceTest
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EntityFrameworkPerfomanceTest(UnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<OrderDto> GetOrdersWithRelationsAsync(int size = 10, int customerId = default)
        {
            var table = _unitOfWork.OrderRepository.TableNoTracking;

            if (customerId != default)
            {
                table = table.Where(x => x.CustomerId == customerId);
            }

            var orders = table
                //.ProjectTo<OrderDto1>(_mapper.ConfigurationProvider)
                .Where(x => x.Id <= size)
                .Include(x => x.Customer)
                .Include(x => x.OrderStatus)
                .Include(x => x.OrderItems)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<OrderDto>>(orders);

            //return table
            //    .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            //    .OrderBy(x => x.Id)
            //    .Take(size)
            //    .ToList();
        }
    }
}
