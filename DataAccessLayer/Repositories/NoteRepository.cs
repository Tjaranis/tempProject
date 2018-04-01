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
    class NoteRepository : INote
    {
        private readonly StackOverflowAppContext _context;

        internal NoteRepository(StackOverflowAppContext context)   //ToDo: dependency injection
        {
            _context = context;
        }

        ///////////////INTERFACE METHOD//////////////////////
        public NoteDTO CreateNoteDTO(int userId, int postId, string body)
        {
            try
            {
                var a = CreateNote(userId, postId, body);
                return NoteMapper.MapNoteToNoteDTO(a);
            }
            catch (Exception ex)
            {
                //   UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }
        
        public NoteDTO GetNoteAsDTO(int userId, int postId)
        {
            var a = GetNote(userId, postId);
            return NoteMapper.MapNoteToNoteDTO(a);
        }

        public IEnumerable<NoteDTO> GetNotesAsDTOs()
        {
            try
            {
                var aList = GetNotes();
                return NoteMapper.MapNoteToNoteDTOs(aList); ;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }

        public bool Update(int userId, int postId, string body)
        {
            Note a = _context.Note.Find(userId, postId);
            if (a == null)
                return false;
            a.Body = body;
            return true;
        }

        public bool Delete(int userId, int postId)
        {
            try
            {
                Note a = _context.Note.Find(userId, postId);
                if (a == null)
                    return false;
                _context.Note.Remove(a);
                return true;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return false;
        }

        //////////////////////NONE INTERFACE METHOD////////////////////////////////


        public Note CreateNote(int userId, int postId, string body)
        {
            try
            {
                var a = new Note()
                {
                    UserId = userId,
                    PostId = postId,
                    CreationDate = DateTime.Now,
                    Body = body
                };
                _context.Note.Add(a);
                _context.SaveChanges();
                return a;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all Note from the database </summary>
        public IEnumerable<Note> GetNotes()
        {
            try
            {
                return _context.Note.ToList();
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get a specific Note from the database </summary>
        public Note GetNote(int userId, int postId)
        {
            try
            {
                return _context.Note.Find(userId, postId);
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }
    }
}
