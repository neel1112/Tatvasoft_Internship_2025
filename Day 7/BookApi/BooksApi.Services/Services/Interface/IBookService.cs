
using BooksApi.Entities.Entities;
using BooksApi.Entities.Models;

namespace BooksApi.Services.Services.Interface
{
    public interface IBookService
    {
        void AddBook(Book book);
        List<Book> GetAll();
        Book? GetBookById(int id);
        Task InsertBook(Book book);
        BookDetails GetBookDetailsById(int id);
    }
}
