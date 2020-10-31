using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Dtos.EntityDtos
{
    public class OrderStatusDto
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int CreateUserId { get; set; }
        public virtual int UpdateUserId { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual IList<OrderDto> Orders { get; set; }
    }
}
