using Microsoft.AspNetCore.Mvc;

namespace CoolLibrary.WebAPI
{
    [ApiController]
    [Route("api/recommended")]
    public class RecommendedController : ControllerBase
    {
        [HttpGet]
        public async virtual Task<string> Get([FromQuery] string genre)
        {
            return "qwerty";
        }
    }
}
