using System.ComponentModel.DataAnnotations;

namespace BooksApi.Entities.Entities
{
    public class BookDetails
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public virtual User User { get; set; }
    }
}
