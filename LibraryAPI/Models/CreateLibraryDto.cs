using LibraryAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class CreateLibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Strett { get; set; }
        public string ZipCode { get; set; }
    }
}
