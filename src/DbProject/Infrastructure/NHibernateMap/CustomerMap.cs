using DbProject.Infrastructure.Dtos;
using DbProject.Infrastructure.Dtos.EntityDtos;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.NHibernateMap
{
    public class CustomerMap : ClassMapping<CustomerDto>
    {
        public CustomerMap()
        {
            Lazy(true);

            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("CUS_Id");
            });

            Property(x => x.Name, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("CUS_Name");
            });

            Property(x => x.ContactName, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("CUS_ContactName");
            });

            Property(x => x.Email, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("CUS_Email");
            });

            Property(x => x.ContactPhone, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("CUS_ContactPhone");
            });

            Property(x => x.CreateDate, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.Column("CUS_CreateDate");
            });

            Property(x => x.UpdateDate, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.Column("CUS_UpdateDate");
            });

            Property(x => x.UpdateUserId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("UpdateUserId");
            });

            Property(x => x.CreateUserId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("CreateUserId");
            });

            Table("tblCustomer");
        }
    }
}
