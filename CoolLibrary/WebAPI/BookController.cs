using CoolLibrary.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CoolLibrary.WebAPI
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        [Route("books")]
        [HttpGet]
        public async virtual Task<string> GetAll([FromQuery] string order)
        {
            return "qwerty";
        }

        [Route("{id}")]
        [HttpGet]
        public async virtual Task<string> GetById(int id)
        {
            return "qwerty";
        }

        [Route("{id}")]
        [HttpDelete]
        public async virtual Task<string> DeleteById([FromQuery] string secret, int id)
        {
            return "qwerty";
        }

        [Route("save")]
        [HttpPost]
        public async virtual Task<string> CreateOrUpdate([FromBody] BookDto book)
        {
            return "qwerty";
        }

        [Route("{id}/review")]
        [HttpPut]
        public async virtual Task<string> AddReview([FromBody] ReviewDto review, int id)
        {
            return "qwerty";
        }

        [Route("{id}/rate")]
        [HttpPut]
        public async virtual Task<string> AddRating([FromBody] RatingDto rating, int id)
        {
            return "qwerty";
        }
    }
}
