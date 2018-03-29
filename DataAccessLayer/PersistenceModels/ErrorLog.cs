using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    internal partial class ErrorLog
    {
        public int Id { get; set; }
        public DateTime DateOccurred { get; set; }
        public string AppLocation { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStacktrace { get; set; }
        public string DeveloperComment { get; set; }
    }
}
