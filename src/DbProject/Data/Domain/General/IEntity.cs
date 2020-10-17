using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Data.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
