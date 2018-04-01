using DataAccessLayer.PersistenceModels;
using DataTransferObjects.BusinessDataAccessDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Mappers
{
    internal static class PostMapper
    {//not made yet

        internal static PostDTO MapPostToPostDTO(Post p)
        {
            if (p == null || p.Id <= 0)
                return null;
            return new PostDTO
            {
                Id = p.Id,
                Title = p.Title,
                Body = p.Body,
                Score = p.Score,
                UserId = p.UserId,
                CreationDate = p.CreationDate,
                PostType = p.PostType,
                PostTypeNavigation = ConvertPostTypeToPostTypeDTO(p.PostTypeNavigation),
                User = ConvertUserToUserDTO(p.User),
                Question = ConvertQuestionToQuestionDTO(p.Question),
                Answer = ConvertAnswerToAnswerDTOs(p.Answer),
                Bookmark = ConvertBookmarkToBookmarkDTOs(p.Bookmark),
                Note= ConvertNoteToNoteDTOs(p.Note),
                PostComment= ConvertPostCommentToPostCommentDTOs(p.PostComment),
                PostLink= ConvertPostLinkToPostLinkDTOs(p.PostLink),
                PostTag= ConvertPostTagToPostTagDTOs(p.PostTag)
                
            };
        }

        internal static IEnumerable<PostDTO> MapPostToPostDTOs(IEnumerable<Post> pList)
        {
            if (pList == null)
                return null;
            List<PostDTO> dtos = new List<PostDTO>();
            foreach (var p in pList)
            {
                if (p.Id <= 0)
                    return null;
                dtos.Add(MapPostToPostDTO(p));
            }
            return dtos;
        }


        //////////////////////Helper////////////////////////////
        ///////calls to the correct mappers for the objects needing to be mapped within the postDTO.

        private static PostTypeDTO ConvertPostTypeToPostTypeDTO(PostType p)
        {
            return PostTypeMapper.MapPostTypeToPostTypeDTO(p);
        }
        private static StackOverflowUserDTO ConvertUserToUserDTO(StackOverflowUser p)
        {
            return StackOverflowUserMapper.MapStackOverflowUserToStackOverflowUserDTO(p);
        }

        private static QuestionDTO ConvertQuestionToQuestionDTO(Question p)
        {
            return QuestionMapper.MapQuestionToQuestionDTO(p);
        }

        private static IEnumerable<AnswerDTO> ConvertAnswerToAnswerDTOs(IEnumerable<Answer> p)
        {
            return AnswerMapper.MapAnswerToAnswerDTOs(p);
        }
        private static IEnumerable<BookmarkDTO> ConvertBookmarkToBookmarkDTOs(IEnumerable<Bookmark> p)
        {
            return BookmarkMapper.MapBookmarkToBookmarkDTOs(p);
        }
        private static IEnumerable<NoteDTO> ConvertNoteToNoteDTOs(IEnumerable<Note> p)
        {
            return NoteMapper.MapNoteToNoteDTOs(p);
        }
        private static IEnumerable<PostCommentDTO> ConvertPostCommentToPostCommentDTOs(IEnumerable<PostComment> p)
        {
            return PostCommentMapper.MapPostCommentToPostCommentDTOs(p);
        }
        private static IEnumerable<PostLinkDTO> ConvertPostLinkToPostLinkDTOs(IEnumerable<PostLink> p)
        {
            return PostLinkMapper.MapPostLinkToPostLinkDTOs(p);
        }
        private static IEnumerable<PostTagDTO> ConvertPostTagToPostTagDTOs(IEnumerable<PostTag> p)
        {
            return PostTagMapper.MapPostTagToPostTagDTOs(p);
        }
    }
}

