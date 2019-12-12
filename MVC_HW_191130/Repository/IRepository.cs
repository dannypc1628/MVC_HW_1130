using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC_HW_191130.Repository
{
    public interface IRepository<T> where T:class
    {
        IUnitOfWork UnitOfWork { get; set; }

        IQueryable<T> All();

        IQueryable<T> Query(Expression<Func<T, bool>> filter);

        T GetSingle(Expression<Func<T, bool>> filter);

        void Create(T entity);

        void Remove(T entity);

    }
}