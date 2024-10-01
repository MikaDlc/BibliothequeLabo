using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository<BLL.Book> _bookService;

        public BookController(IBookRepository<BLL.Book> bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.Get());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody]BookPost book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            _bookService.Insert(book.ToBLL());
            return CreatedAtAction(nameof(Get), book);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute]int id,[FromBody] BookPost book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            _bookService.Update(id, book.ToBLL());
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
