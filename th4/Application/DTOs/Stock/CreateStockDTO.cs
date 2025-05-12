using System.ComponentModel.DataAnnotations;

namespace th4.Application.DTOs.Stock
{
    public class CreateStockDTO
    {
        [Required]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        public string CompenyName { get; set; } = string.Empty;
        [Required]
        public decimal Purchase { get; set; }
        [Required]
        public decimal LastDiv { get; set; }
        [Required]
        public string Industry { get; set; } = string.Empty;
        [Required]
        public long MaketCap { get; set; }
    }
}
