namespace LibraryAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Strett { get; set; }
        public string ZipCode { get; set; }
        public virtual Library Library { get; set; }
    }
}
