
using BooksApi.Entities.Context;
using BooksApi.Entities.Entities;
using BooksApi.Repository.Repositories.Interface;

namespace BooksApi.Repository.Repositories
{
    public class BookRepository(BookDbContext bookDbContext)   : IBookRepository
    {
        private readonly BookDbContext _dbContext = bookDbContext;

        public async Task InsertBook(BookDetails bookDetails)
        {
            await _dbContext.BookDetails.AddAsync(bookDetails);
            await _dbContext.SaveChangesAsync();
        }

        public BookDetails GetById(int id)
        {
            return _dbContext.BookDetails.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
