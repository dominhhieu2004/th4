namespace th4.Application.DTOs.Comment
{
    public class CommentDTO
    {
        public int Id { get; set; } // 🔹 Thêm khóa chính
        public int? StockId { get; set; }
        //navigation
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
