using AutoMapper;
using librar.data.Entities;
using library.bll.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, addBookDto>().ReverseMap();
        CreateMap<Book, addBookDto>();
        CreateMap<Category, addCategoryDto>();
        CreateMap<Category, addCategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
