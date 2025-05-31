using BooksApi.Entities.Entities;
using BooksApi.Models;
using BooksApi.Services;
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
        [Authorize]
        public async Task<ActionResult> AddBook(BookDetails bookDetails)
        {
            await _bookService.InsertBook(bookDetails);
            return Ok("Book created !");
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
