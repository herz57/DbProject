using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Dtos
{
    public class CustomerCategoryProductsDto
    {
        public string Name { get; set; }
        public List<CountDto> CategoryProducts { get; set; }
    }
}
