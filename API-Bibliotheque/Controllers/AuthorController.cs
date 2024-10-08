using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository<BLL.Author> _authorService;
        public AuthorController(IAuthorRepository<BLL.Author> authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.Get().Select(a => a.ToAPI()));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var author = _authorService.Get(id);
                return Ok(author.ToAPIDetails());
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthorPost author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest();
                }
                _authorService.Insert(author.ToBLL());
                return CreatedAtAction(nameof(Get), author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
