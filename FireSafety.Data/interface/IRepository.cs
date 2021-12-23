using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Data.repository
{
   public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> List();

        List<TEntity> List(Expression<Func<TEntity, bool>> eresult);

        IQueryable<TEntity> listQueryable();
        int Insert(TEntity obj);
        int Update(TEntity obj);
        int Delete(TEntity obj);
        int Save();
        TEntity Find(Expression<Func<TEntity, bool>> eresult);

    }
}
