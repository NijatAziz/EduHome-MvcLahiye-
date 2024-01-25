using EduHome.Core.DTOS.Comment;
using EduHome.Core.DTOS.Course;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Implementations
{
    public class CourseCommentService : ICourseCommentService
    {
        private readonly ICommentRepository _courseCommentRepository;
        private readonly UserManager<User> _userManager;

        public CourseCommentService(ICommentRepository courseCommentRepository, UserManager<User> userManager)
        {
            _courseCommentRepository = courseCommentRepository;
            _userManager = userManager;
        }

        public async Task<CommentGetDto> GetCommentAsync(int courseId)
        {
            var commentEntity = await _courseCommentRepository.GetAsync(c => c.CourseId == courseId && !c.IsDeleted);

            if (commentEntity == null)
            {
                return null;
            }

            var commentDto = new CommentGetDto
            {
                UserId = commentEntity.UserId,
                Subject = commentEntity.Subject,
                Message = commentEntity.Message,
                Course = new CourseGetDto { Id = (int)commentEntity.CourseId }
            };

            return commentDto;
        }

        public async Task<CommentGetDto> AddCommentAsync(CommentGetDto commentDto, int courseId, string userId)
        {
            Comment commentEntity = new()
            {
                UserId = userId,
                Subject = commentDto.Subject,
                Message = commentDto.Message,
                CreatedAt = DateTime.Now,
                CourseId = courseId,
            };

            await _courseCommentRepository.AddAsync(commentEntity);
            await _courseCommentRepository.SaveChangesAsync();

            CommentGetDto addedCommentDto = new CommentGetDto
            {
                UserId = commentEntity.UserId,
                Subject = commentEntity.Subject,
                Message = commentEntity.Message,
                Course = new CourseGetDto { Id = (int)commentEntity.CourseId }
            };

            return addedCommentDto;
        }

        public async Task<CommentGetDto> UpdateCommentAsync(int commentId, string userId, CommentGetDto updatedCommentDto)
        {
            var existingComment = await _courseCommentRepository.GetAsync(c => c.ID == commentId && c.UserId == userId && !c.IsDeleted);

            if (existingComment == null)
            {
                return null;
            }

            existingComment.Subject = updatedCommentDto.Subject;
            existingComment.Message = updatedCommentDto.Message;
            existingComment.UpdatedDate = DateTime.Now;

            await _courseCommentRepository.UpdateAsync(existingComment);
            await _courseCommentRepository.SaveChangesAsync();

            var updatedCommentDtoResult = new CommentGetDto
            {
                UserId = existingComment.UserId,
                Subject = existingComment.Subject,
                Message = existingComment.Message,
                Course = new CourseGetDto { Id = (int)existingComment.CourseId }
            };

            return updatedCommentDtoResult;
        }

        public async Task RemoveCommentAsync(int commentId, string userId)
        {
            var existingComment = await _courseCommentRepository.GetAsync(c => c.ID == commentId && c.UserId == userId && !c.IsDeleted);

            if (existingComment == null)
            {
                throw new ItemNotFoundExcpetion("Comment is not found");
            }

            existingComment.IsDeleted = true;
            await _courseCommentRepository.UpdateAsync(existingComment);
            await _courseCommentRepository.SaveChangesAsync();
        }


        public async Task<List<CommentWithUserNameDto>> GetCommentsWithUserNamesAsync(int courseId)
        {
            var comments = _courseCommentRepository.GetQuery(c => c.CourseId == courseId && !c.IsDeleted)
                                                       .Include(x => x.Course)
                                                       .Include(x => x.User);

            var commentsWithUserNames = new List<CommentWithUserNameDto>();

            if (comments != null)
            {
                foreach (var comment in comments)
                {
                    var user = await _userManager.FindByIdAsync(comment.UserId);

                    var commentWithUserName = new CommentWithUserNameDto
                    {
                        Id = comment.ID,
                        UserId = comment.UserId,
                        UserName = user?.UserName,
                        Subject = comment.Subject,
                        Message = comment.Message,
                        Course = new CourseGetDto { Id = (int)comment.CourseId }
                    };

                    commentsWithUserNames.Add(commentWithUserName);
                }
            }

            return commentsWithUserNames;
        }

    }

}
