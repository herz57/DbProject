using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.Domain
{
    public class Category : ModifyDate, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }

        public User CreateUser { get; set; }
        public User UpdateUser { get; set; }


        private ICollection<Product> _products;

        public virtual ICollection<Product> Products
        {
            get => _products ??= new List<Product>();
            set => _products = value;
        }
    }
}
