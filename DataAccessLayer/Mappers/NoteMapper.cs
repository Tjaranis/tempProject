using System;
using System.Collections.Generic;
using DataAccessLayer.PersistenceModels;
using DataTransferObjects.BusinessDataAccessDTOs;

namespace DataAccessLayer.Mappers
{
    internal class NoteMapper
    {

        internal static NoteDTO MapNoteToNoteDTO(Note a)
        {
            if (a == null || a.PostId <= 0)
                return null;
            return CreatedNoteDTO(a);
        }

        internal static IEnumerable<NoteDTO> MapNoteToNoteDTOs(IEnumerable<Note> aList)
        {
            if (aList == null)
                return null;
            List<NoteDTO> dtos = new List<NoteDTO>();
            foreach (var a in aList)
            {
                if (a.PostId <= 0)
                    return null;
                dtos.Add(CreatedNoteDTO(a));
            }
            return dtos;
        }

        ////////////////Helper//////////////////
        private static NoteDTO CreatedNoteDTO(Note a)
        {
            return new NoteDTO
            {
                UserId=a.UserId,
                PostId=a.PostId,
                CreationDate=a.CreationDate,
                Body=a.Body,
                Post=ConvertNoteToNoteDTO(a.Post),
                User=ConvertStackOverflowUserToStackOverflowUserDTO(a.User)
            };
        }
        
        ////////////////Helper///////////////////////

        private static PostDTO ConvertNoteToNoteDTO(Post p)
        {
            return PostMapper.MapPostToPostDTO(p);
        }
        private static StackOverflowUserDTO ConvertStackOverflowUserToStackOverflowUserDTO(StackOverflowUser s)
        {
            return StackOverflowUserMapper.MapStackOverflowUserToStackOverflowUserDTO(s);
        }

    }
}