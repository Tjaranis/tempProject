using DataAccessLayer.Interfaces;
using DataAccessLayer.Mappers;
using DataAccessLayer.PersistenceModels;
using DataTransferObjects.BusinessDataAccessDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly StackOverflowAppContext _context;

        internal AnswerRepository(StackOverflowAppContext context)   //ToDo: dependency injection
        {
            _context = context;
        }

        ///////////////INTERFACE METHOD//////////////////////

        public AnswerDTO CreateAnswerDTO(int post_id, int parent_id)
        {
            try
            {
                var a = CreateAnswer(post_id, parent_id);
                return AnswerMapper.MapAnswerToAnswerDTO(a);
            }
            catch (Exception ex)
            {
            //   UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }

        public bool Delete(int post_id)
        {
            try
            {
                Answer a = _context.Answer.Find(post_id);
                if (a == null)
                    return false;
                _context.Answer.Remove(a);
                return true;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return false;
        }

        public AnswerDTO GetAnswerAsDTO(int AnswerPostID)
        {
            var a = GetAnswer(AnswerPostID);
            return AnswerMapper.MapAnswerToAnswerDTO(a);
        }
        ///convert to list of AnswerDTO.
        public IEnumerable<AnswerDTO> GetAnswersAsDTOs()
        {
            try
            {
                var aList = GetAnswers();
                return AnswerMapper.MapAnswerToAnswerDTOs(aList); ;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }

        public bool Update(int post_id, int parent_id, bool accepted_answer, bool editable)
        {
            Answer a = _context.Answer.Find(post_id);
            if (a == null)
                return false;
            a.ParentId = parent_id;
            a.AcceptedAnswer = Convert.ToInt16(accepted_answer);
            a.Editable = Convert.ToInt16(editable);
            return true;
        }

        //////////////////////NONE INTERFACE METHOD////////////////////////////////

        
        public Answer CreateAnswer(int post_id, int parent_id)
        {
            try
            {
                var a = new Answer() {
                    PostId=post_id, ParentId=parent_id,
                    AcceptedAnswer=0, Editable=0 };
                _context.Answer.Add(a);
                _context.SaveChanges();
                return a;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all answer from the database </summary>
        public IEnumerable<Answer> GetAnswers()
        {
            try
            {
                return _context.Answer.ToList();
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get a specific answer from the database </summary>
        public Answer GetAnswer(int AnswerID)
        {
            try
            {
                return _context.Answer.Find(AnswerID);
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }
        
    }
}
