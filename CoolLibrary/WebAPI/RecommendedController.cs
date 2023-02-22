using CoolLibrary.BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoolLibrary.WebAPI
{
    [ApiController]
    [Route("api/recommended")]
    public class RecommendedController : ControllerBase
    {
        private readonly BookService _bookService;

        public RecommendedController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetTopRate([FromQuery] string genre)
        {
            return Ok(await _bookService.GetTopRateAsync(genre));
        }
    }
}