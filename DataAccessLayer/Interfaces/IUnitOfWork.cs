

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        /***  IRepositories here  ***/
        
        /// <summary> Save all current changes for the Repositories  </summary>
        int Complete();
    }

}
