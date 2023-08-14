using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Exceptions;
using LibraryAPI.Models;
using System.Net;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        int Create(CreateBookDto dto);
        List<BookDto> GetAll();
        BookDto GetById(int BookId);
        void Delete(int BookId);
    }

    public class BookService : IBookService
    {
        private readonly LibraryDBContext _context;
        private readonly IMapper _mapper;

        public BookService(LibraryDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public int Create(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }
        public List<BookDto> GetAll()
        {
            var books = _context.Books.ToList();
            var dto = _mapper.Map<List<BookDto>>(books);
            return dto;
        }
        public BookDto GetById(int BookId)
        {
            var book = _context.Books.FirstOrDefault(d => d.Id == BookId);
            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }
            var dto = _mapper.Map<BookDto>(book);
            return dto;
        }
        public void Delete(int BookId) 
        {
            var book = _context.Books.FirstOrDefault(d => d.Id == BookId);
            if (book == null)
            {
                throw new NotFoundException("Book not found");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
