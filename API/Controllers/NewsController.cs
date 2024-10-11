using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // API không yêu cầu xác thực
        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult GetActiveNews()
        {
            var activeNews = _newsService.GetNews();
            return Ok(activeNews);
        }
    }
}
