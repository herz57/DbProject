using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbProject.Data.Domain.General
{
    public class Address
    {
        [Column("Address1")]
        public string Address1 { get; set; }

        [Column("Address2")]
        public string Address2 { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("County")]
        public string County { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("PostCode")]
        public string PostCode { get; set; }
    }
}
