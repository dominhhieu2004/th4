using th4.Application.DTOs.Stock;
using th4.Domain.Models;

namespace th4.Domain.Interface
{
    public interface IStocksRepository
    {
        Task<List<Stock>> GetAllStocksAsync();
        Task<Stock?> GetStockByIdAsync(int id);
        Task<Stock?> GetStockBySymbolAsync(string symbol);
        Task<Stock> AddStockAsync(Stock stock);
        Task<Stock?> UpdateStockAsync(int id, UpdateStockDTO updateStock);
        Task<Stock?> DeleteCommentAsync(int id);
        Task<bool> StockExists(int id);
    }
}
