using EduHome.Core.DTOS.Comment;
using EduHome.Core.Entities;
using EduHomeServices.Exceptions;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class CourseCommentController : Controller
    {
        private readonly ICourseCommentService _courseCommentService;
        private readonly UserManager<User> _userManager;

        public CourseCommentController(ICourseCommentService courseCommentService, UserManager<User> userManager)
        {
            _courseCommentService = courseCommentService;
            _userManager = userManager;
        }


        public async Task<ActionResult> GetComment(int commentId)
        {
            var comment = await _courseCommentService.GetCommentAsync(commentId);
            if (comment == null)
            {
                throw new ItemNotFoundExcpetion("Comment not found.");
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(int courseId, CommentGetDto commentDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user is null)
            {
                return RedirectToAction("Login", "Account");
            }
            commentDto.UserId = user.Id;

            var addedComment = await _courseCommentService.AddCommentAsync(commentDto, courseId, user.Id);
            return Redirect(Request.Headers["Referer"].ToString());
        }


        [HttpPost]
        public async Task<ActionResult> UpdateComment(int commentId, string userId, CommentGetDto updatedCommentDto)
        {
            var updatedComment = await _courseCommentService.UpdateCommentAsync(commentId, userId, updatedCommentDto);
            if (updatedComment == null)
            {
                throw new ItemNotFoundExcpetion("Comment not found or user does not have access to update this comment.");
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<ActionResult> RemoveComment(int commentId, string userId)
        {

            await _courseCommentService.RemoveCommentAsync(commentId, userId);
            return Redirect(Request.Headers["Referer"].ToString());

        }
    }

}
