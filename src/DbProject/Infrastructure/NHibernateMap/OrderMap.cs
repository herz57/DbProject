using DbProject.Infrastructure.Dtos.EntityDtos;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.NHibernateMap
{
    public class OrderMap : ClassMapping<OrderDto>
    {
        public OrderMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("ORD_Id");
            });

            Property(b => b.DeliveryDetailId, x =>
            {
                x.Column("ORD_DELDET_Id");
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.Price, x =>
            {
                x.Column("ORD_Price");
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
            });

            Property(b => b.Currency, x =>
            {
                x.Column("ORD_Currency");
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.CreateDate, x =>
            {
                x.Column("ORD_CreateDate");
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(false);
            });

            Property(b => b.UpdateDate, x =>
            {
                x.Column("ORD_UpdateDate");
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(false);
            });

            ManyToOne(x => x.Customer, x =>
            {
                Lazy(true);
                x.Column("ORD_CUS_Id");
            });

            ManyToOne(x => x.OrderStatus, x =>
            {
                x.Column("ORD_ORDSTAT_Id");
            });

            Bag(x => x.OrderItems,
                
                c => { c.Key(k => k.Column("ORDITEM_ORD_Id")); c.Inverse(true); c.Lazy(NHibernate.Mapping.ByCode.CollectionLazy.Lazy); },
                r => r.OneToMany());

            Table("tblOrder");
        }
    }
}
