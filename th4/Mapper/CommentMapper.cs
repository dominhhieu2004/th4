using th4.Application.DTOs.Comment;
using th4.Domain.Models;

namespace th4.Mapper
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comments commentDTO) 
        {
            return new CommentDTO
            {
                Id = commentDTO.Id,
                StockId = commentDTO.StockId,
                Title = commentDTO.Title,
                Content = commentDTO.Content,
                CreatedOn = commentDTO.CreatedOn
            };         
        }

        public static Comments ToCreateComment(this CreateComment comments, int stockId)
        {
            return new Comments
            {
              
                StockId = stockId,
                Title = comments.Title,
                Content = comments.Content,
              
            };
        }
    }
}
