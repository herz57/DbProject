using DbProject.Infrastructure.Dtos.EntityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Dtos
{
    public class CustomerDto
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string Email { get; set; }
        public virtual string ContactPhone { get; set; }
        public virtual int CreateUserId { get; set; }
        public virtual int UpdateUserId { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual IList<OrderDto> Orders { get; set; }
    }
}
