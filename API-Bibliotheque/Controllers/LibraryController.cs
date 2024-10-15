using Commun_Bibliotheque.Repositories;
using BLL = BLL_Bibliotheque.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
using Microsoft.AspNetCore.Authorization;

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
            try
            {
                var library = _libraryRepository.Get(id);
                return Ok(library.ToAPIDetails());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize("adminRequired")]
        [HttpPost]
        public IActionResult Post([FromBody] LibraryPost library)
        {
            try
            {
                if (library == null)
                    return BadRequest();
                _libraryRepository.Insert(library.ToBLL());
                return CreatedAtAction(nameof(Get), library);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
