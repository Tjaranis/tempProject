

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{

    /// <summary> This class is completely generic and doesn't necessarily have to do with the application (specific entities) </summary>
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        /// <summary> This is protected because in the derived repositories we are going to use it. </summary>
        protected readonly DbContext Context;


        public BaseRepository(DbContext context)
        {
            Context = context;
        }


  
        public bool Add(TEntity entity)
        {           
            try
            {
                Context.Set<TEntity>().Add(entity);               
            }
            catch (Exception ex)
            {
                //ToDo: log error
                return false;
            }
            return true;
        }



        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                //ToDo: log error               
            }
            return null;
        }



        public TEntity Get(int id)
        {
            try
            {
                return Context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                //ToDo: log error       
            }
            return null;
        }



        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                //ToDo: log error       
            }
            return null;
        }



        public void Remove(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Remove(entity);
            }
            catch (Exception ex)
            {
                //ToDo: log error       
            }           
        }

    }
}
