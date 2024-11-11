using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {

        T Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);

    }
}