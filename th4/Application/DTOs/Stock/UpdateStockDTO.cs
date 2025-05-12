using System.ComponentModel.DataAnnotations;

namespace th4.Application.DTOs.Stock
{
    public class UpdateStockDTO
    {
        public string Symbol { get; set; } = string.Empty;
        public string CompenyName { get; set; } = string.Empty;


        [Required]
        [Range(1, 10000)]
        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;
        public long MaketCap { get; set; }
    }
}
