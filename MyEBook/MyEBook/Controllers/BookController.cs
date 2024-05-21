using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEBook.Models.DTOs;
using MyEBook.Models.Entities;
using MyEBook.Repositories;

namespace MyEBook.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBook()
        {
            try
            {
                return Ok(await _bookRepository.GetAllBooksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookRepository.GetBookAsync(id);

            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDTO bookDTO)
        {
            var newBook = await _bookRepository.AddBookAsync(bookDTO);
            return Ok(newBook);
        }

    }
}
