using DataAccessLayer.PersistenceModels;
using DataTransferObjects.BusinessDataAccessDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Mappers
{
    public class PostMapper
    {//not made yet
        internal static PostDTO PostMapper(Answer a)
        {
            if (a == null || a.PostId <= 0)
                return null;
            return new AnswerDTO
            {
                PostId = a.PostId,
                ParentId = a.ParentId,
                AcceptedAnswer = a.AcceptedAnswer,
                Editable = a.Editable,
                Parent = Posta.ParentId
            };
        }

        internal PostDTO MapPostToPostDTO(Post parentPost)
        {
            throw new NotImplementedException();
        }
    }
}
