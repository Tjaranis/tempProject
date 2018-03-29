

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        /***  IRepositories here  ***/
        IErrorLogRepository ErrorLogs { get; set; }

        /// <summary> Save all current changes for the Repositories  </summary>
        int Complete();
    }

}
