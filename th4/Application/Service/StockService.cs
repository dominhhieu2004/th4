using Microsoft.EntityFrameworkCore;
using th4.Application.DTOs.Stock;
using th4.Domain.Interface;
using th4.Domain.Models;
using th4.Infrastructure;

namespace th4.Application.Service
{
    public class StockService : IStocksRepository
    {
        private readonly ApplicationDBContext _context;

        public StockService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Stock> AddStockAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteCommentAsync(int id)
        {
            var dele = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if(dele == null)
                return null;

             _context.Stocks.Remove(dele);
            await _context.SaveChangesAsync();
            return dele;
        }

        public async Task<List<Stock>> GetAllStocksAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetStockByIdAsync(int id)
        {
            var stock = _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id);
            return await stock;
        }

        public Task<Stock?> GetStockBySymbolAsync(string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(x => x.Id == id);
        }

        public async Task<Stock?> UpdateStockAsync(int id, UpdateStockDTO updateStock)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(c => c.Id == id);
            if (existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = updateStock.Symbol;
            existingStock.CompenyName = updateStock.CompenyName;
            existingStock.Purchase = updateStock.Purchase;
            existingStock.LastDiv = updateStock.LastDiv;
            existingStock.Industry = updateStock.Industry;
            existingStock.MaketCap = updateStock.MaketCap;
            _context.Stocks.Update(existingStock);
            await _context.SaveChangesAsync();
            return existingStock;
        }
    }
}
