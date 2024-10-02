using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenreRepository<BLL.Genre> _genreService;
        public GenreController(IGenreRepository<BLL.Genre> genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_genreService.Get());
        }

        [HttpGet("{Genre}")]
        public IActionResult Get(string Genre)
        {
            var genre = _genreService.Get(Genre);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GenrePost genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }
            _genreService.Insert(genre.ToBLL());
            return CreatedAtAction(nameof(Get), genre);
        }
    }
}
