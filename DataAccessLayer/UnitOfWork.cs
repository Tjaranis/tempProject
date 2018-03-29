

using DataAccessLayer.Interfaces;
using System;
using System.IO;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private StackOverflowAppContext _context;
        /***  IRepositories here  ***/


        /// <summary> Instantiate a EF-Context and then use it across all repositories.  </summary>
        /// <param name="context"> Injected instance of the applications DB context </param>  
        public UnitOfWork(StackOverflowAppContext context)
        {
            _context = context;
        }


        /// <summary> Commit the changes for all current DB sets </summary>   
        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //ToDo log error
                return -1;
            }
        }

    }
}
