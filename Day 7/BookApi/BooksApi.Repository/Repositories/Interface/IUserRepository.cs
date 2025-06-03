using BooksApi.Entities.Entities;
using BooksApi.Entities.Models;
using BooksApi.Entities.Models.Request;

namespace BooksApi.Repository.Repositories.Interface
{
    public interface IUserRepository
    {
        Task AddUser(User user);

        Task<List<UserModel>> GetAllUserAsync(UserRequestModel model);

        User? Login(string email, string password);
    }
}
