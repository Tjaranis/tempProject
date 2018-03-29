
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace DataAccessLayer.Interfaces
{

    /// <summary> Generic base interface with generic operations. Theses operations will be inherited by other IReopositories.</summary>
    /// <typeparam name="TEntity"></typeparam>
    interface IBaseRepository<TEntity> where TEntity : class  
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);        
        void Remove(TEntity entity);        
    }

}
