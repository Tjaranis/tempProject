
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
// using ServiceLayer.ViewModels;
// using DataTransferObjects;

namespace ServiceLayer.BusinessLayer
{
    public sealed class Facade
    {
     
        private readonly IUnitOfWork _unitOfWork;


        /// <summary> This class is the mediator between the service APIs of the application and the data access layer.
        /// The interaction with the unit of work repositories, committing changes, mapping and logging will be done from here. </summary>
        /// <param name="uow"> Injected instance of the unit of work interface </param>
        public Facade(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }


        /// <summary> Log an error/exception which occurred within the system </summary>
        /// <param name="comment"> Any additional description or developer comment to describe the error. </param>
        /// <param name="occurredWithin"> Should describe specifically where the error occurred. </param>
        /// <param name="exception"> Optional: a exception which was caught during a specific execution of a procedure. </param>
        public void LogApplicationError(string comment, string occurredWithin, Exception exception = null)
        {

            _unitOfWork.Complete();
        }

    }

}
