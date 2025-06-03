using BooksApi.Entities.Entities;
using BooksApi.Entities.Models;
using BooksApi.Services.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) 
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Route("Add")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult> AddBook(Book book)
        {
            await _bookService.InsertBook(book);
            return Ok("Book created !");
        }

        [HttpPost]
        [Route("Edit")]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult> EditBook(BookDetails bookDetails)
        {
            // Forbid()
            return Ok("Book updated !");
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_bookService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            var res = _bookService.GetBookDetailsById(id);

            if (res != null) { return Ok(res); }

            return NotFound("Book not found!");
        }

        // To Update Book
        // To Delete Book
    }
}
