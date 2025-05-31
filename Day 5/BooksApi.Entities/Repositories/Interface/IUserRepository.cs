using BooksApi.Entities.Entities;

namespace BooksApi.Entities.Repositories.Interface
{
    public interface IUserRepository
    {
        Task AddUser(User user);

        User? Login(string username, string password);
    }
}
