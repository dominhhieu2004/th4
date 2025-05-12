using System.ComponentModel.DataAnnotations.Schema;

namespace th4.Domain.Models
{
    [Table("Comments")]
    public class Comments
    {
        public int Id { get; set; } // 🔹 Thêm khóa chính
        public int? StockId { get; set; }
        //navigation
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Stock? Stock { get; set; }
    }
}
