using EduHome.Core.DTOS.Comment;
using EduHome.Core.Entities;
using EduHomeServices.Exceptions;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class BlogCommentController : Controller
    {
        private readonly IBlogCommentService _blogCommentService;
        private readonly UserManager<User> _userManager;

        public BlogCommentController(IBlogCommentService blogCommentService, UserManager<User> userManager)
        {
            _blogCommentService = blogCommentService;
            _userManager = userManager;
        }


        public async Task<ActionResult> GetComment(int commentId)
        {
            var comment = await _blogCommentService.GetCommentAsync(commentId);
            if (comment == null)
            {
                throw new ItemNotFoundExcpetion("Comment not found.");
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(int blogId, CommentGetDto commentDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null)
            {
                return RedirectToAction("Login", "Account");
            }
            commentDto.UserId = user.Id;

            var addedComment = await _blogCommentService.AddCommentAsync(commentDto, blogId, user.Id);
            return Redirect(Request.Headers["Referer"].ToString());
        }


        [HttpPost]
        public async Task<ActionResult> UpdateComment(int commentId, string userId, CommentGetDto updatedCommentDto)
        {
            var updatedComment = await _blogCommentService.UpdateCommentAsync(commentId, userId, updatedCommentDto);
            if (updatedComment == null)
            {
                throw new ItemNotFoundExcpetion("Comment not found or user does not have access to update this comment.");
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<ActionResult> RemoveComment(int commentId, string userId)
        {

            await _blogCommentService.RemoveCommentAsync(commentId, userId);
            return Redirect(Request.Headers["Referer"].ToString());

        }
    }
}
