using DbProject.Infrastructure.Dtos.EntityDtos;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.NHibernateMap
{
    public class OrderItemMap : ClassMapping<OrderItemDto>
    {
        public OrderItemMap()
        {
            Lazy(true);

            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("ORDITEM_Id");
            });

            Property(x => x.ProductId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("ORDITEM_PROD_Id");
            });

            Property(x => x.Quantity, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("ORDITEM_Quantity");
            });

            ManyToOne(x => x.Order, x =>
            {
                x.Column("ORDITEM_ORD_Id");
            });

            Table("tblOrderItem");
        }
    }
}
