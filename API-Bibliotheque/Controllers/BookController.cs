using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                var book = _bookService.Get(id);
                return Ok(book.ToAPIDetails());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize("adminRequired")]
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
                return NotFound(ex.Message);
            }
        }
    }
}
