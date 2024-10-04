using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
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
            return Ok(_bookService.Get().Select(b => b.ToAPI()));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id);
            if (book == null)
            {
                return BadRequest("Book not exist");
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookPost book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest();
                }

                int bookId = _bookService.Insert(book.ToBLL());


                if (bookId == -1)
                    return BadRequest("Book already exists");
                else
                    return CreatedAtAction(nameof(Get), book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] BookPost book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            _bookService.Update(id, book.ToBLL());
            return NoContent();
        }
    }
}
