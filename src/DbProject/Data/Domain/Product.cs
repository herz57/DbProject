using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.Domain
{
    public class Product : ModifyDate, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }

        public Category Category { get; set; }
        public User CreateUser { get; set; }
        public User UpdateUser { get; set; }


        private ICollection<OrderItem> _orderItems;

        public virtual ICollection<OrderItem> OrderItems
        {
            get => _orderItems ??= new List<OrderItem>();
            set => _orderItems = value;
        }
    }
}

