using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class CreateBookDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public int NumberOfPages { get; set; }
        public string Language { get; set; }
    }
}
