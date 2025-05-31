
using BooksApi.Entities.Entities;
using BooksApi.Models;

namespace BooksApi.Services.Services.Interface
{
    public interface IUserService
    {
        Task AddUser(User user);
        User? Login(string username, string password);
    }
}
