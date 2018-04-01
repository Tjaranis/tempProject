using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObjects.BusinessDataAccessDTOs;

namespace DataAccessLayer.Interfaces
{
    public interface IAnswerRepository
    {
        AnswerDTO CreateAnswerDTO(int post_id, int parent_id);
        AnswerDTO GetAnswerAsDTO(int AnswerPostID);
        IEnumerable<AnswerDTO> GetAnswersAsDTOs();
        //the bools are tinyints in the DB. as such it is converted to 0 or 1 on rescieved.
        bool Update(int post_id, int parent_id, bool accepted_answer, bool editable);
        bool Delete(int post_id);
        
        /*****   CCS: assignment 4.1   *****/
        // Category GetCategory(int categoryID);
        // IEnumerable<Category> GetCategories();
        // Category CreateCategory(string name, string description);
    }
}
