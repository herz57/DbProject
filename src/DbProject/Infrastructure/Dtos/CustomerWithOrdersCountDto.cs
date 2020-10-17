using DbProject.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Models
{
    public class CustomerWithOrdersCountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserName { get; set; }
        public int PlacedOrdersCount { get; set; }
        public int PreparedOrdersCount { get; set; }
        public int DispatchedOrdersCount { get; set; }
    }
}
