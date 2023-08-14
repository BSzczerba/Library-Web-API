using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Exceptions;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public interface IStockService
    {
        int Create(int LibraryId, CreateStockDto dto);
        void DeleteAll(int LibraryId);
        void DeleteById(int LibraryId, int StockId);
        List<StockDto> GetAll(int LibraryId);
        StockDto GetById(int LibraryId, int StockId);
    }

    public class StockService : IStockService
    {
        private readonly LibraryDBContext _context;
        private readonly IMapper _mapper;

        public StockService(LibraryDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public List<StockDto> GetAll(int LibraryId)
        {
            var library = GetLibrary(LibraryId);
            var stocks = library.Stocks.ToList();
            var dto = _mapper.Map<List<StockDto>>(stocks);
            return dto;
        }
        public StockDto GetById(int LibraryId, int StockId)
        {
            var library = GetLibrary(LibraryId);
            var stock = GetStock(StockId, library);
            var dto = _mapper.Map<StockDto>(stock);
            return dto;
        }
        public int Create(int LibraryId, CreateStockDto dto)
        {
            var library = GetLibrary(LibraryId);
            var stock = _mapper.Map<Stock>(dto);
            var book = _context.Books.FirstOrDefault(x => x.Id == stock.bookId);
            if (book is null) 
            {
                throw new Exception("Book not found");
            }
            stock.LibraryId = LibraryId;
            stock.Library = library;
            stock.book = book;
            library.Stocks.Add(stock);
            _context.SaveChanges();
            return stock.Id;
        }
        public void DeleteAll(int LibraryId)
        {
            var library = GetLibrary(LibraryId);
            _context.RemoveRange(library.Stocks);
            _context.SaveChanges();
        }
        public void DeleteById(int LibraryId, int StockId)
        {
            var library = GetLibrary(LibraryId);
            var stock = GetStock(StockId,library);
            library.Stocks.Remove(stock);
            _context.SaveChanges();
        }
        private Library GetLibrary(int LibraryId)
        {
            var library = _context.Libraries
               .Include(s => s.Stocks).ThenInclude(s => s.book)
               .FirstOrDefault(d => d.Id == LibraryId);
            if (library == null)
            {
                throw new NotFoundException("Library not found");
            }
            return library;
        }
        private Stock GetStock(int StockId,Library library)
        {
            var stock = _context.Stocks
                .Include(s => s.book)
                .FirstOrDefault(r => r.Id == StockId);
            if (stock is null || stock.LibraryId != library.Id)
            {
                throw new NotFoundException("Stock not found");
            }
            return stock;
        }
    }
}
