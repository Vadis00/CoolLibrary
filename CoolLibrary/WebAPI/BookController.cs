using CoolLibrary.BLL.Service;
using CoolLibrary.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CoolLibrary.WebAPI
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll([FromQuery] string order)
        {
            return Ok(await _bookService.GetAllAsync(order));
        }

        [Route("{id}")]
        [HttpGet]
        public virtual async Task<IActionResult> GetById(int id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }

        [Route("{id}")]
        [HttpDelete]
        public virtual async Task<IActionResult> DeleteById([FromQuery] string secret, int id)
        {
            await _bookService.DeleteByIdAsync(id, secret);

            return NoContent();
        }

        [Route("save")]
        [HttpPost]
        public virtual async Task<IActionResult> CreateOrUpdate([FromBody] NewBookDto bookDto)
        {
            return Ok(await _bookService.CreateOrUpdateAsync(bookDto));
        }

        [Route("{id}/review")]
        [HttpPut]
        public virtual async Task<IActionResult> AddReview([FromBody] ReviewDto review, int id)
        {
            return Ok(await _bookService.AddReviewAsync(review, id));
        }

        [Route("{id}/rate")]
        [HttpPut]
        public virtual async Task<IActionResult> AddRating([FromBody] RatingDto rating, int id)
        {
            return Ok(await _bookService.AddRateAsync(rating, id));
        }
    }
}