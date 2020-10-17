using DbProject.Data.Domain.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Models
{
    public class DeliveryDetailDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
