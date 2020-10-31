using DbProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Dtos.EntityDtos
{
    public class OrderDto
    {
        public virtual int Id { get; set; }
        public virtual int DeliveryDetailId { get; set; }
        public virtual double Price { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int OrderStatusId { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }

        public virtual CustomerDto Customer { get; set; }
        public virtual OrderStatusDto OrderStatus { get; set; }

        //public virtual IList<OrderItemDto> OrderItems { get; set; }

        private IList<OrderItemDto> _orderItems;
        public virtual IList<OrderItemDto> OrderItems
        {
            get { return _orderItems ?? (_orderItems = new List<OrderItemDto>()); }
            set { _orderItems = value; }
        }
    }
}
