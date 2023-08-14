using LibraryAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class CreateStockDto
    {
        [Required]
        public int bookId { get; set; }
        public int Amount { get; set; }
    }
}
