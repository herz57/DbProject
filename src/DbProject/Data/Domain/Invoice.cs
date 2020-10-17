using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.Domain
{
    public class Invoice : ModifyDate, IEntity<int>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public double Price { get; set; }
        public string NameOnCard { get; set; }
        public string LastForDigit { get; set; }

        public Order Order { get; set; }
    }
}

