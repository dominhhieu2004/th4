using System.ComponentModel.DataAnnotations;
using th4.Application.DTOs.Stock;
using th4.Domain.Models;

namespace th4.Mapper
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stock)
        {
            return new StockDTO
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompenyName = stock.CompenyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MaketCap = stock.MaketCap,
                Comments = stock.Comments.Select(c => c.ToCommentDTO()).ToList()
            };
        }

        public static Stock ToCreateStockDTO(this CreateStockDTO createStock)
        {
            return new Stock
            {
                Symbol = createStock.Symbol,
                CompenyName = createStock.CompenyName,
                Purchase = createStock.Purchase,
                LastDiv = createStock.LastDiv,
                Industry = createStock.Industry,
                MaketCap = createStock.MaketCap

            };
        }
    }
}

