

using DataTransferObjects.BusinessDataAccessDTOs;


namespace DataAccessLayer.Interfaces
{
    public interface IErrorLogRepository
    {
        bool Log(LoggingDTO dto);
    }

}
