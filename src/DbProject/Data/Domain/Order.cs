using DbProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbProject.Data.Domain
{
    public class Order : ModifyDate, IEntity<int>
    {
        public int Id { get; set; }
        public int DeliveryDetailId { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }

        public Customer Customer { get; set; }
        public DeliveryDetail DeliveryDetail { get; set; }
        public OrderStatus OrderStatus { get; set; }


        private ICollection<Invoice> _invoices;
        private ICollection<OrderItem> _orderItems;

        public virtual ICollection<Invoice> Invoices
        {
            get => _invoices ??= new List<Invoice>();
            set => _invoices = value;
        }

        public virtual ICollection<OrderItem> OrderItems
        {
            get => _orderItems ??= new List<OrderItem>();
            set => _orderItems = value;
        }
    }
}

