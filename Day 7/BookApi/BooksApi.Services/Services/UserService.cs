using BooksApi.Entities.Entities;
using BooksApi.Entities.Models;
using BooksApi.Entities.Models.Request;
using BooksApi.Repository.Repositories.Interface;
using BooksApi.Services.Services.Interface;

namespace BooksApi.Services
{
    // For CRUD on books
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // To Add User
        public async Task AddUser(User user)
        {
            await this._userRepository.AddUser(user);
        }

        public Task<List<UserModel>> GetAllUserAsync(UserRequestModel model)
        {
            return _userRepository.GetAllUserAsync(model);
        }

        // Login API
        public User? Login(string email, string password)
        {
            return this._userRepository.Login(email, password);
        }
    }
}
