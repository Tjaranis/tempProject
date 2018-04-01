using DataTransferObjects.BusinessDataAccessDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    interface IPost
    {
        PostDTO CreatePostDTO(
            string title, string body, int score, 
            int userId, DateTime creationDate, string PostType
            );
        PostDTO GetPostAsDTO(int PostID);
        IEnumerable<PostDTO> GetPostsAsDTOs();
        //the bools are tinyints in the DB. as such it is converted to 0 or 1 on rescieved.
        bool Update(int post_id, string title, string body, int score);
        bool UpdateScore(int post_id, int score);
        bool Delete(int post_id);
    }
}

