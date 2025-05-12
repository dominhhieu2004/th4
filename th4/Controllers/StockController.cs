using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using th4.Application.DTOs.Stock;
using th4.Domain.Interface;
using th4.Domain.Models;
using th4.Infrastructure;
using th4.Mapper;

namespace th4.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : ControllerBase
    {
        private readonly IStocksRepository _stocksRepository;
        private readonly ApplicationDBContext _context;

        public StockController(IStocksRepository stocksRepository, ApplicationDBContext context)
        {
            _stocksRepository = stocksRepository;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState); //thực hiện toàn bộ validate trong DTO

            var stock = await _stocksRepository.GetAllStocksAsync();
            var stockDto = stock.Select(s => s.ToStockDTO());
            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var stock = await _stocksRepository.GetStockByIdAsync(id);
            if (stock == null)
                return NotFound();
            var stockDto = stock.ToStockDTO();
            return Ok(stockDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] CreateStockDTO createStock)
        {
            var stockModel = createStock.ToCreateStockDTO();
            await _stocksRepository.AddStockAsync(stockModel);
            return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, stockModel.ToStockDTO());

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpateStocks(int id, [FromBody] UpdateStockDTO updateStock)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var stock = await _stocksRepository.UpdateStockAsync(id, updateStock);
            if (stock == null)
                return NotFound();

            var stockDto = stock.ToStockDTO();
            return Ok(stockDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stocksRepository.DeleteCommentAsync(id);
            if (stock == null)
                return NotFound();
            return Ok( new { stock, message = "Xoá cổ phiếu thành công" });
        }
    }
}
