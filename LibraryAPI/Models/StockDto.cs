using LibraryAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class StockDto
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public virtual string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public int Amount { get; set; }
        public int LibraryId { get; set; }
    }
}
