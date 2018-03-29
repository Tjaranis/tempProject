

using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.IO;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private StackOverflowAppContext _context;
        /***  IRepositories here  ***/
        public IErrorLogRepository ErrorLogs { get; set; }


        /// <summary> Instantiate a EF-Context and then use it across all repositories.  </summary>
        /// <param name="context"> Injected instance of the applications DB context </param>  
        public UnitOfWork(StackOverflowAppContext context)
        {
            _context = context;
            ErrorLogs = new ErrorLogRepository(_context);
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
                ErrorLogs.Log(new DataTransferObjects.BusinessDataAccessDTOs.LoggingDTO
                {
                    AppLocation = "UnitOfWork - Complete()",
                    DeveloperComment = "Unit of Work could not commit any current changes to the DB sets ",
                    ExceptionMessage = ex.Message,
                    ExceptionStacktrace = ex.StackTrace
                });
                return -1;
            }
        }

    }
}
