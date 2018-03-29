

using DataAccessLayer.PersistenceModels;
using DataTransferObjects.BusinessDataAccessDTOs;
using System;

namespace DataAccessLayer.Mappers
{
    internal class ErrorLogMapper
    {

        public ErrorLog MapDtoToModel(LoggingDTO dto)
        {
            return new ErrorLog
            {
                AppLocation = dto.AppLocation,
                DateOccurred = DateTime.Now,
                DeveloperComment = dto.DeveloperComment,
                ExceptionMessage = dto.ExceptionMessage ?? null,
                ExceptionStacktrace = dto.ExceptionStacktrace ?? null,
            };
        }

    }

}
