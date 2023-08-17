using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/book")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _bookService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _bookService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult AddBook([FromBody] CreateBookDto dto)
        {
            int bookId = _bookService.Create(dto);
            return Created($"api/library/{bookId}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
