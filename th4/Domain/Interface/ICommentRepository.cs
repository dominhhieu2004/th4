using th4.Application.DTOs.Comment;
using th4.Domain.Models;

namespace th4.Domain.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comments>> GetAllCommentsAsync();
        Task<Comments?> GetCommentByIdAsync(int id);
        Task<Comments> AddCommentAsync(Comments comment);
        Task<Comments?> UpdateCommentAsync(int id, UpateComment comment);
        Task<Comments?> DeleteCommentAsync(int id);
    }
}
