using DbModels.ModelBases;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectBase.DbRepository
{
    public interface IRepository<T> where T : class ,ITablesBase
    {
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Remove(object id);
        void RemoveByExpression(Expression<Func<T, bool>> predicate);
        Task RemoveAsync(object id);
        void RemoveAll(List<T> entities);
        Task RemoveAllAsync(List<T> entities);
        T GetById(object id);
        List<T> GetByExpression(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(object id);
        IList<T> GetAllWithIncludes(params Expression<Func<T, object>>[] predicates);
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();
        void CreatNew(T entity);
        Task CreatNewAsync(T entity);

    }
}
