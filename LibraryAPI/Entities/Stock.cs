namespace LibraryAPI.Entities
{
    public class Stock
    {
        public int Id { get; set; }       
        public int bookId { get; set; }
        public virtual Book book { get; set; }
        public int Amount { get; set; }
        public int LibraryId { get; set; }  
        public virtual Library Library { get; set; }
    }
}
