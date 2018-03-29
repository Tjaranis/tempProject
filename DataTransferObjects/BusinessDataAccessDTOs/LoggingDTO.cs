
using System;

namespace DataTransferObjects.BusinessDataAccessDTOs
{
    public class LoggingDTO
    {
        public int Id { get; set; }
        public DateTime DateOccurred { get; set; }
        public string AppLocation { get; set; }
        public string ExceptionMessage { get; set; } = null;
        public string ExceptionStacktrace { get; set; } = null;
        public string DeveloperComment { get; set; }
    }

}
