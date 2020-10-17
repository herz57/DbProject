using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Dtos
{
    public class CustomerProductsDto
    {
        public string Name { get; set; }
        public List<CountDto> Products { get; set; }
    }
}
