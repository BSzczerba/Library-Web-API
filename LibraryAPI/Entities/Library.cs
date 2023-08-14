namespace LibraryAPI.Entities
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Stock> Stocks { get; set; }
    }
}