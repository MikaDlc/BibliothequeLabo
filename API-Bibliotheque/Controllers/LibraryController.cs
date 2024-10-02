using Commun_Bibliotheque.Repositories;
using BLL = BLL_Bibliotheque.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private ILibraryRepository<BLL.Library> _libraryRepository;
        public LibraryController(ILibraryRepository<BLL.Library> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_libraryRepository.Get().Select(l => l.ToAPI()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var library = _libraryRepository.Get(id);
            if (library == null)
                return NotFound();
            return Ok(library);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LibraryPost library)
        {
            if (library == null)
                return BadRequest();
            _libraryRepository.Insert(library.ToBLL());
            return CreatedAtAction(nameof(Get), library);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] LibraryPost library)
        {
            if (library == null)
                return BadRequest();
            _libraryRepository.Update(id, library.ToBLL());
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _libraryRepository.Delete(id);
            return NoContent();
        }

    }
}
