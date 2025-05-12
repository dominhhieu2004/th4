using Microsoft.EntityFrameworkCore;
using th4.Application.DTOs.Comment;
using th4.Domain.Interface;
using th4.Domain.Models;
using th4.Infrastructure;

namespace th4.Application.Service
{
    public class CommentService : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Comments> AddCommentAsync(Comments comment)
        {
             _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comments?> DeleteCommentAsync(int id)
        {
            var commentId = await _context.Comments.FirstOrDefaultAsync(_ => _.Id == id);
            if (commentId == null)
                return null;
            _context.Comments.Remove(commentId);
            await _context.SaveChangesAsync();
            return commentId;
        }

        public async Task<List<Comments>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comments?> GetCommentByIdAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            return comment;
        }

        public async Task<Comments?> UpdateCommentAsync(int id, UpateComment comment)
        {
            var commentId= await _context.Comments.FirstOrDefaultAsync(_ => _.Id == id);

            commentId.Title = comment.Title;
            commentId.Content = comment.Content;

            _context.Comments.Update(commentId);
            await _context.SaveChangesAsync();
            return commentId;
        }
    }
}
