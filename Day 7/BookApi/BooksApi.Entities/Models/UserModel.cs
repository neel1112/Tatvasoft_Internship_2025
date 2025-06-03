using BooksApi.Entities.Entities;

namespace BooksApi.Entities.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<BookDetails> BookDetails { get; set; }
    }
}
