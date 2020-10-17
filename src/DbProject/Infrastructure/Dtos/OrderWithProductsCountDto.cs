using DbProject.Data.Domain;
using DbProject.Data.Domain.General;
using DbProject.Data.Enums;
using DbProject.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Models
{
    public class OrderWithProductsCountDto
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string OrderStatus { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
        public DeliveryDetailDto DeliveryDetail { get; set; }
        public int OrderedProductsCount { get; set; }
    }
}
