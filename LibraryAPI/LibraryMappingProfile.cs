using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;

namespace LibraryAPI
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Library, LibraryDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Strett, c => c.MapFrom(s => s.Address.Strett))
                .ForMember(m => m.ZipCode, c => c.MapFrom(s => s.Address.ZipCode))
                .ForMember(m => m.Stocks, c => c.MapFrom(s => s.Stocks));
            CreateMap<CreateLibraryDto, Library>()
                .ForMember(m => m.Address, c => c.MapFrom(s => new Address() { City = s.City, Strett = s.Strett, ZipCode = s.ZipCode }));
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<Stock, StockDto>()
                .ForMember(m => m.BookTitle, c => c.MapFrom(s => s.book.Title))
                .ForMember(m => m.BookAuthor, c => c.MapFrom(s => s.book.Author));
            CreateMap<CreateStockDto,Stock>();
            CreateMap<RegisterUserDto, User>();
        }
    }
}
