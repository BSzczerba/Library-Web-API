using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Exceptions;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public interface ILibraryService
    {
        int Create(CreateLibraryDto dto);
        void Delete(int LibraryId);
        List<LibraryDto> GetAll();
        LibraryDto GetById(int LibraryId);
    }

    public class LibraryService : ILibraryService
    {

        private readonly LibraryDBContext _context;
        private readonly IMapper _mapper;

        public LibraryService(LibraryDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public int Create(CreateLibraryDto dto)
        {
            var library = _mapper.Map<Library>(dto);
            _context.Libraries.Add(library);
            _context.SaveChanges();
            return library.Id;
        }
        public List<LibraryDto> GetAll()
        {
            var library = _context.Libraries
                .Include(r => r.Stocks).ThenInclude(s => s.book)
                .Include(r => r.Address)
                .ToList();
            var dto = _mapper.Map<List<LibraryDto>>(library);
            return dto;
        }
        public LibraryDto GetById(int LibraryId)
        {
            var library = _context.Libraries
                .Include(r => r.Stocks).ThenInclude(s => s.book)
                .Include(r => r.Address)
                .FirstOrDefault(d => d.Id == LibraryId);
            if (library == null)
            {
                throw new NotFoundException("Library not found");
            }
            var dto = _mapper.Map<LibraryDto>(library);
            return dto;
        }
        public void Delete(int LibraryId)
        {
            var library = _context.Libraries.FirstOrDefault(d => d.Id == LibraryId);
            if (library == null)
            {
                throw new NotFoundException("Library not found");
            }
            _context.Libraries.Remove(library);
            _context.SaveChanges();
        }
    }
}
