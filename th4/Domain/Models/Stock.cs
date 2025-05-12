using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace th4.Domain.Models
{
    [Table("Stock")]
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompenyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;
        public long MaketCap { get; set; }

        public List<Comments> Comments { get; set; } = new List<Comments>();
    }
}
