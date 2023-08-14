using LibraryAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class LibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Strett { get; set; }
        public string ZipCode { get; set; }
        public virtual List<StockDto> Stocks { get; set; }
    }
}
