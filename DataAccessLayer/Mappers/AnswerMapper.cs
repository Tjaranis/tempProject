using DataAccessLayer.PersistenceModels;
using DataTransferObjects.BusinessDataAccessDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Mappers
{
    internal static class AnswerMapper
    {
        internal static AnswerDTO MapAnswerToAnswerDTO(Answer a)
        {
            if (a == null || a.PostId <= 0)
                return null;
            return CreatedAnswerDTO(a);
        }
        
        internal static IEnumerable<AnswerDTO> MapAnswerToAnswerDTOs(IEnumerable<Answer> aList)
        {
            if (aList == null)
                return null;
            List<AnswerDTO> dtos = new List<AnswerDTO>();
            foreach (var a in aList)
            {
                if (a.PostId <= 0)
                    return null;
                dtos.Add(CreatedAnswerDTO(a));
            }
            return dtos;
        }

        ////////////////Helper//////////////////
        private static AnswerDTO CreatedAnswerDTO(Answer a)
        {
            return new AnswerDTO
            {
                PostId = a.PostId,
                ParentId = a.ParentId,
                AcceptedAnswer = a.AcceptedAnswer,
                Editable = a.Editable,
                Parent = ConvertPostToPostDTO(a.Parent)
            };
        }

        private static PostDTO ConvertPostToPostDTO(Post parentPost)
        {
            return PostMapper.MapPostToPostDTO(parentPost);
        }

    }
}

