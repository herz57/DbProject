using Dapper;
using DbProject.Data.Domain;
using DbProject.Data.Repository.Abstract;
using DbProject.Infrastructure.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Mapper;
using SqlMapper = Dapper.SqlMapper;
using DbProject.Infrastructure.Dtos.EntityDtos;
using DbProject.Infrastructure.Dtos;

namespace DbProject.Data.Repository
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IOptions<ConnectionStringsOptions> _connectionOptions;
        public DapperRepository(IOptions<ConnectionStringsOptions> connectionOptions)
        {
            _connectionOptions = connectionOptions;
        }

        public List<OrderDto> GetOrdersWithRelations(int size = 10, int customerId = default)
        {
            List<OrderDto> orders = new List<OrderDto>();
            using (IDbConnection conn = new SqlConnection(_connectionOptions.Value.AppConnection))
            {
                var builder = new SqlBuilder();
                var query = builder.AddTemplate(@$"SELECT
                    ord.ORD_Id AS Id, ord.ORD_DELDET_Id AS DeliveryDetailId, ord.ORD_Price AS Price, ord.ORD_Currency AS Currency, ord.ORD_CUS_Id AS CustomerId, ord.ORD_ORDSTAT_Id AS OrderStatusId, ord.ORD_CreateDate AS CreateDate, ord.ORD_UpdateDate AS UpdateDate,
                    cus.CUS_Id AS Id, cus.CUS_Name AS Name, cus.CUS_ContactName AS ContactName, cus.CUS_Email AS Email, cus.CUS_ContactPhone AS ContactPhone, cus.CUS_CreateDate AS CreateDate, cus.CUS_UpdateDate AS UpdateDate, cus.CreateUserId, cus.UpdateUserId,
                    ordstat.ORDSTAT_Id AS Id, ordstat.ORDSTAT_Name AS Name, ordstat.ORDSTAT_CreateDate AS CreateDate, ordstat.ORDSTAT_UpdateDate AS UpdateDate, ordstat.ORDSTAT_CreateUserId AS CreateUserId, ordstat.ORDSTAT_UpdateUserId AS UpdateUserId,
                    orditem.ORDITEM_Id AS Id, orditem.ORDITEM_ORD_Id AS OrderId, orditem.ORDITEM_Quantity AS Quantity 
                        FROM tblOrder ord
                    inner join tblCustomer cus on ord.ORD_CUS_Id = cus.CUS_Id
                    inner join tblOrderStatus ordstat on ord.ORD_ORDSTAT_Id = ordstat.ORDSTAT_Id
                    inner join tblOrderItem orditem on ord.ORD_Id = orditem.ORDITEM_ORD_Id
                    /**where**/
                    order by ord.ORD_Id");

                builder.Where("ord.ORD_Id <= @size", new { size });
                if (customerId != default)
                {
                    builder.Where("ord.ORD_CUS_Id = @customerId", new { customerId });
                }

                var orderDictionary = new Dictionary<int, OrderDto>();
                orders = conn.Query<OrderDto, CustomerDto, OrderStatusDto, OrderItemDto, OrderDto>(query.RawSql, (ord, cus, ordstat, orditem) => 
                {
                    OrderDto orderEntry;
                    ord.OrderStatus = ordstat;
                    ord.Customer = cus;

                    if (!orderDictionary.TryGetValue(ord.Id, out orderEntry))
                    {
                        orderEntry = ord;
                        orderEntry.OrderItems = new List<OrderItemDto>();
                        orderDictionary.Add(ord.Id, orderEntry);
                    }

                    orderEntry.OrderItems.Add(orditem);

                    return orderEntry;
                }, param: query.Parameters, splitOn: "Id").Distinct().ToList();
                return orders;
            }
        }
    }
}
