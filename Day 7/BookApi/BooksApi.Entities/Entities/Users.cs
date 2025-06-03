using System.ComponentModel.DataAnnotations;

namespace BooksApi.Entities.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<BookDetails> BookDetails { get; set; } = [];
    }

    /*
        public class ACL
        {
            [Key]
            public int Id { get; set; }
            public int UserID { get; set; }
            public int BookId { get; set; }
            //Read/Write
            public string Permission { get; set; }
        }
    */
}
