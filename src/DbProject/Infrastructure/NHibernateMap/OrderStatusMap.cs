using DbProject.Infrastructure.Dtos.EntityDtos;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.NHibernateMap
{
    public class OrderStatusMap : ClassMapping<OrderStatusDto>
    {
        public OrderStatusMap()
        {
            Lazy(true);

            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("ORDSTAT_Id");
            });

            Property(x => x.Name, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("ORDSTAT_Name");
            });

            Property(x => x.CreateDate, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.Column("ORDSTAT_CreateDate");
            });

            Property(x => x.UpdateDate, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.Column("ORDSTAT_UpdateDate");
            });

            Property(x => x.UpdateUserId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("ORDSTAT_UpdateUserId");
            });

            Property(x => x.CreateUserId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("ORDSTAT_CreateUserId");
            });

            Table("tblOrderStatus");
        }
    }
}

