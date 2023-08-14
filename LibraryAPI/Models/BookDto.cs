﻿namespace LibraryAPI.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public int NumberOfPages { get; set; }
        public string Language { get; set; }
    }
}
