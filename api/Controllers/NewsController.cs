using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _news;
        public NewsController(INewsService newsService)
        {
            _news = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentNews(){
            var news = await _news.GetLatestNewsAsync();
            if(news == null) return BadRequest("No more request available");
            return Ok(news);
        }
    }
}