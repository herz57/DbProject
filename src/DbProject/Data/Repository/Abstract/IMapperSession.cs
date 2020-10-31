using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Data.Repository.Abstract
{
    public interface IMapperSession<T>
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(T entity);
        Task Delete(T entity);
        ISession Session { get; }
    }
}
