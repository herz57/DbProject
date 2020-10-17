using DbProject.Data.Domain.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.Domain
{
    public class DeliveryDetail : ModifyDate, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public Address Address { get; set; }


        private ICollection<Order> _orders;

        public virtual ICollection<Order> Orders
        {
            get => _orders ??= new List<Order>();
            set => _orders = value;
        }
    }
}