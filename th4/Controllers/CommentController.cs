using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using th4.Application.DTOs.Comment;
using th4.Domain.Interface;
using th4.Domain.Models;
using th4.Infrastructure;
using th4.Mapper;

namespace th4.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStocksRepository _stocksRepository;
        private readonly ApplicationDBContext _context;

        public CommentController(ICommentRepository commentRepository, IStocksRepository stocksRepository, ApplicationDBContext context)
        {
            _commentRepository = commentRepository;
            _stocksRepository = stocksRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comments = await _commentRepository.GetAllCommentsAsync();
            return Ok(comments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetIdComment(int id) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentGet = await _commentRepository.GetCommentByIdAsync(id);
            if (commentGet == null)
                return NotFound();
            var commentModel = commentGet.ToCommentDTO();

            return Ok(commentModel);
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> CreateComment([FromBody] CreateComment createComment, int stockId)
        { 
         if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _stocksRepository.StockExists(stockId)) 
            {
                return BadRequest("Không tìm thấy cổ phiếu");
            }

            var commentModel = createComment.ToCreateComment(stockId);
            await _commentRepository.AddCommentAsync(commentModel);
            return CreatedAtAction(nameof(GetIdComment), new { id = commentModel.Id }, commentModel.ToCommentDTO());

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpateComment upateComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentModel = await _commentRepository.UpdateCommentAsync(id, upateComment);
            if (commentModel == null)
                return NotFound("Không tìm thấy bình luận cần cập nhật");

            return Ok(commentModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) { 
          if(!ModelState.IsValid)
                return BadRequest(ModelState);

          var commentDelete = await _commentRepository.DeleteCommentAsync(id);
          
          return Ok(commentDelete);
        }
    }
}
