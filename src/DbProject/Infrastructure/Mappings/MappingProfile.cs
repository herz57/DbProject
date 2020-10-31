using AutoMapper;
using DbProject.Data.Domain;
using DbProject.Infrastructure.Dtos;
using DbProject.Infrastructure.Dtos.EntityDtos;
using DbProject.Infrastructure.Enums;
using DbProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbProject.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, Category>();
            CreateMap<DeliveryDetail, DeliveryDetailDto>();
            CreateMap<Invoice, Category>();

            CreateMap<Order, OrderWithProductsCountDto>()
                .ForMember(o => o.OrderStatus, opt => opt.MapFrom(o => o.OrderStatus.Name))
                .ForMember(o => o.OrderedProductsCount, opt => opt.MapFrom(o => o.OrderItems.Where(oi => oi.OrderId.Equals(o.Id)).Sum(oi => oi.Quantity)));

            CreateMap<Customer, CustomerWithOrdersCountDto>()
                .ForMember(o => o.UserName, opt => opt.MapFrom(o => o.UpdateUser.UserName))
                .ForMember(o => o.PlacedOrdersCount, opt => opt.MapFrom(x => x.Orders.Count(o => o.CustomerId.Equals(x.Id) && o.OrderStatusId.Equals((int)OrderStatusEn.Placed))))
                .ForMember(o => o.PreparedOrdersCount, opt => opt.MapFrom(x => x.Orders.Count(o => o.CustomerId.Equals(x.Id) && o.OrderStatusId.Equals((int)OrderStatusEn.Prepared))))
                .ForMember(o => o.DispatchedOrdersCount, opt => opt.MapFrom(x => x.Orders.Count(o => o.CustomerId.Equals(x.Id) && o.OrderStatusId.Equals((int)OrderStatusEn.Dispatched))));

            CreateMap<Order, OrderDto>()
                .ForMember(o => o.OrderStatus, opt => opt.MapFrom(o => o.OrderStatus))
                .ForMember(o => o.Customer, opt => opt.MapFrom(o => o.Customer))
                .ForMember(o => o.OrderItems, opt => opt.MapFrom(o => o.OrderItems));

            CreateMap<OrderDto, Order>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<OrderStatus, OrderStatusDto>();
            CreateMap<OrderStatusDto, OrderStatus>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}
