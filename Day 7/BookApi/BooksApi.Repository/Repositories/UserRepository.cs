
using BooksApi.Entities.Context;
using BooksApi.Entities.Entities;
using BooksApi.Entities.Models;
using BooksApi.Entities.Models.Request;
using BooksApi.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Repository.Repositories
{
    public class UserRepository(BookDbContext bookDbContext) : IUserRepository
    {
        private readonly BookDbContext _dbContext = bookDbContext;

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetAllUserAsync(UserRequestModel model)
        {
            var query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Search))
            {
                query = query.Where(u => u.Name.ToLower().Contains(model.Search.ToLower()) || u.Email.ToLower().Contains(model.Search.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(model.SortBy) && model.SortBy == "Name")
            {
                if (model.SortDirection == "asc")
                    query = query.OrderBy(u => u.Name);
                else
                    query = query.OrderByDescending(u => u.Name);
            }
            else if (!string.IsNullOrWhiteSpace(model.SortBy) && model.SortBy == "Id")
            {
                if (model.SortDirection == "asc")
                    query = query.OrderBy(u => u.Id);
                else
                    query = query.OrderByDescending(u => u.Id);
            }

            query = query.Skip(model.PageNumber * model.PageSize).Take(model.PageSize);

            var dataQuery = query.Include(u => u.BookDetails).Select(u => new UserModel()
            {
                Name = u.Name,
                Email = u.Email,
                Id = u.Id,
                Role = u.Role,
                BookDetails = u.BookDetails.ToList()
            });
            
            return await dataQuery.ToListAsync();
        }

        public User? Login(string username, string password)
        {
            var user = _dbContext.Users.Where(x => x.Email == username && x.Password == password).FirstOrDefault();
            return user;
        }
    }
}
