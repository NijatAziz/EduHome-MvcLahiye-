using EduHome.Core.DTOS.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface IBlogCommentService
    {
        Task<CommentGetDto> GetCommentAsync(int commentId);
        Task<CommentGetDto> AddCommentAsync(CommentGetDto commentDto, int blogId, string userId);
        Task<CommentGetDto> UpdateCommentAsync(int commentId, string userId, CommentGetDto updatedCommentDto);
        Task RemoveCommentAsync(int commentId, string userId);
        Task<List<CommentWithUserNameDto>> GetCommentsWithUserNamesAsync(int courseId);
    }
}
