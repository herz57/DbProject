using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Dtos.EntityDtos
{
    public class OrderItemDto
    {
        public virtual int Id { get; set; }
        public virtual int OrderId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual OrderDto Order { get; set; }
    }
}
