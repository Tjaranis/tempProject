using DataTransferObjects.BusinessDataAccessDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    interface INote
    {
        NoteDTO CreateNoteDTO(int userId, int postId, string body);
        NoteDTO GetNoteAsDTO(int userId, int postId);
        IEnumerable<NoteDTO> GetNotesAsDTOs();
        //the bools are tinyints in the DB. as such it is converted to 0 or 1 on rescieved.
        bool Update(int userId, int postId, string body);
        bool Delete(int userId, int postId);
    }
}