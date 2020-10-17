using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.Domain
{
    public class OrderItem : ModifyDate, IEntity<int>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
