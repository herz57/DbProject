﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.Domain
{
    public class OrderStatus : ModifyDate, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }

        public User CreateUser { get; set; }
        public User UpdateUser { get; set; }


        private ICollection<Order> _orders;

        public virtual ICollection<Order> Orders
        {
            get => _orders ??= new List<Order>();
            set => _orders = value;
        }
    }
}
