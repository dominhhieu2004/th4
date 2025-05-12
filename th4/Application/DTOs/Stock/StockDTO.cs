using th4.Application.DTOs.Comment;

namespace th4.Application.DTOs.Stock
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompenyName { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;
        public long MaketCap { get; set; }

        public List<CommentDTO> Comments { get; set; }
    }
}
