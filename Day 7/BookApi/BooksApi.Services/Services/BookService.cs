using BooksApi.Entities.Entities;
using BooksApi.Entities.Models;
using BooksApi.Repository.Repositories.Interface;
using BooksApi.Services.Services.Interface;

namespace BooksApi.Services
{
    // For CRUD on books
    public class BookService : IBookService
    {
        private List<Book> _books;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _books = new List<Book>();
        }

        // To Add Book
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        // To Get All Books
        public List<Book> GetAll()
        {
            return _books;
        }

        // To Get Single Book
        public Book? GetBookById(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        public async Task InsertBook(Book book)
        {
            BookDetails details = new BookDetails()
            {
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                UserId = book.UserId
            };
            await _bookRepository.InsertBook(details);
        }


        public BookDetails GetBookDetailsById(int id)
        {
            return _bookRepository.GetById(id);
        }

        // To Update Book
        // To Delete Book
    }
}
