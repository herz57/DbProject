using DbProject.Data.Domain.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DbProject.Data.Domain
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        
        //todo: would you use this approach if you need to search users by name?
        [Encrypted]
        public string UserName { get; set; }
        [Encrypted]
        public string Email { get; set; }
        [Encrypted]
        public string Phone { get; set; }
        [Encrypted]
        public string Mobile { get; set; }


        private ICollection<OrderStatus> _createdOrderStatuses;
        private ICollection<OrderStatus> _updatedOrderStatuses;
        private ICollection<AuditLog> _createdAuditLogs;
        private ICollection<AuditLog> _updatedAuditLogs;
        private ICollection<Category> _createdCategories;
        private ICollection<Category> _updatedCategories;
        private ICollection<Product> _createdProducts;
        private ICollection<Product> _updatedProducts;
        private ICollection<Customer> _createdCustomers;
        private ICollection<Customer> _updatedCustomers;

        public virtual ICollection<OrderStatus> CreatedOrderStatuses
        {
            get => _createdOrderStatuses ??= new List<OrderStatus>();
            set => _createdOrderStatuses = value;
        }

        public virtual ICollection<OrderStatus> UpdatedOrderStatuses
        {
            get => _updatedOrderStatuses ??= new List<OrderStatus>();
            set => _updatedOrderStatuses = value;
        }

        public virtual ICollection<AuditLog> CreatedAuditLogs
        {
            get => _createdAuditLogs ??= new List<AuditLog>();
            set => _createdAuditLogs = value;
        }

        public virtual ICollection<AuditLog> UpdatedAuditLogs
        {
            get => _updatedAuditLogs ??= new List<AuditLog>();
            set => _updatedAuditLogs = value;
        }

        public virtual ICollection<Category> CreatedCategories
        {
            get => _createdCategories ??= new List<Category>();
            set => _createdCategories = value;
        }

        public virtual ICollection<Category> UpdatedCategories
        {
            get => _updatedCategories ??= new List<Category>();
            set => _updatedCategories = value;
        }

        public virtual ICollection<Product> CreatedProducts
        {
            get => _createdProducts ??= new List<Product>();
            set => _createdProducts = value;
        }

        public virtual ICollection<Product> UpdatedProducts
        {
            get => _updatedProducts ??= new List<Product>();
            set => _updatedProducts = value;
        }

        public virtual ICollection<Customer> CreatedCustomers
        {
            get => _createdCustomers ??= new List<Customer>();
            set => _createdCustomers = value;
        }

        public virtual ICollection<Customer> UpdatedCustomers
        {
            get => _updatedCustomers ??= new List<Customer>();
            set => _updatedCustomers = value;
        }
    }
}
