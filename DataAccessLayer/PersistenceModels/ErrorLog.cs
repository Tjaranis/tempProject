using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public DateTime DateOccurred { get; set; } = DateTime.Now;
        public string AppLocation { get; set; }
        public string ExceptionMessage { get; set; } = null;
        public string ExceptionStacktrace { get; set; } = null;
        public string DeveloperComment { get; set; }
    }
}
