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
    class PostRepository : IPost
    {

        private readonly StackOverflowAppContext _context;

        internal PostRepository(StackOverflowAppContext context)   //ToDo: dependency injection
        {
            _context = context;
        }

        ///////////////INTERFACE METHOD//////////////////////

        public PostDTO CreatePostDTO(string title, string body, int score, int userId, DateTime creationDate, string PostType)
        {
            try
            {
                var p = CreatePost(title, body, score, userId, creationDate, PostType);
                return PostMapper.MapPostToPostDTO(p);
            }
            catch (Exception ex)
            {
                //   UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }

        public bool Update(int post_id, string title, string body, int score)
        {
            Post p = _context.Post.Find(post_id);
            if (p == null)
                return false;
            p.Title = title;
            p.Body = body;
            p.Score = score;
            return true;
        }

        public bool UpdateScore(int post_id, int score)
        {
            Post p = _context.Post.Find(post_id);
            if (p == null)
                return false;
            p.Score = score;
            return true;
        }

        public bool Delete(int post_id)
        {
            try
            {
                Post p = _context.Post.Find(post_id);
                if (p == null)
                    return false;
                _context.Post.Remove(p);
                return true;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return false;
        }

        public PostDTO GetPostAsDTO(int PostPostID)
        {
            var p = GetPost(PostPostID);
            return PostMapper.MapPostToPostDTO(p);
        }
        ///convert to list of PostDTO.
        public IEnumerable<PostDTO> GetPostsAsDTOs()
        {
            try
            {
                var pList = GetPosts();
                return PostMapper.MapPostToPostDTOs(pList); ;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }

        //////////////////////NONE INTERFACE METHOD////////////////////////////////


        public Post CreatePost(string title, string body, int score, int userId, DateTime creationDate, string PostType)
        {
            try
            {
                var p = new Post()
                {
                    Title = title,
                    Body = body,
                    Score=0,
                    UserId=userId,
                    CreationDate=creationDate,
                    PostType=PostType
                };
                _context.Post.Add(p);
                _context.SaveChanges();
                return p;
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all Post from the database </summary>
        public IEnumerable<Post> GetPosts()
        {
            try
            {
                return _context.Post.ToList();
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get p specific Post from the database </summary>
        public Post GetPost(int PostID)
        {
            try
            {
                return _context.Post.Find(PostID);
            }
            catch (Exception ex)
            {
                //UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }
        
    }
}
