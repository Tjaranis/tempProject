
using DataAccessLayer.Interfaces;
using DataAccessLayer.Mappers;
using DataAccessLayer.PersistenceModels;
using DataTransferObjects.BusinessDataAccessDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    internal class ErrorLogRepository : IErrorLogRepository
    {
        private readonly StackOverflowAppContext _context;

        public ErrorLogRepository(StackOverflowAppContext context)
        {
            _context = context;
        }


        /// <summary> Save data to the ErrorLog table in the DB </summary>
        /// <param name="dto"> The object containing the value </param>
        public bool Log(LoggingDTO dto)
        {
            if (ValidateData(dto))
            {
                try
                {
                    ErrorLog model = new ErrorLogMapper().MapDtoToModel(dto);
                    _context.ErrorLog.Add(model);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }              
            }
            else
            {
                try
                {
                    _context.ErrorLog.Add(new ErrorLog
                    {
                        AppLocation = "ErrorLogRepository - Log()",
                        DateOccurred = DateTime.Now,
                        DeveloperComment = "An error could not be logged because at least one required field was missing."
                    });
                }
                catch (Exception)
                {
                }              
            }
            return false;
        }


        private bool ValidateData(LoggingDTO l)
        {
            if (string.IsNullOrEmpty(l.AppLocation))
                return false;
            if (string.IsNullOrEmpty(l.DeveloperComment))
                return false;
            return true;
        }

    }
}
