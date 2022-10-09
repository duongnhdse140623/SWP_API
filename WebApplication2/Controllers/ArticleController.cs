using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP_API.Models;

namespace SWP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly JournalContext _journalContext;

        public ArticleController(JournalContext context)
        {
            _journalContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TblArticle>>> GetArticle()
        {
            return Ok(await _journalContext.TblArticles.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TblArticle>>> AddArticle(TblArticle article)
        {
            _journalContext.Add(article);
            return Ok(_journalContext);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblArticle>> GetArticle(string id)
        {
            var article = await _journalContext.TblArticles.FindAsync(id);
            if(article == null)
            {
                return BadRequest("Article not found");
            }
            return Ok(article);
        }

    }
}
