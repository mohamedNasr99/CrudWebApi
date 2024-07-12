using AutoMapper;
using bookproject.Models;
using bookproject.DTOs;

namespace bookproject.ConfigureAutomapper
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Author, authorDto>();
            CreateMap<Category, categoryDto>();
            CreateMap<Book, bookDto>();
            CreateMap<bookDto, Book>();
            CreateMap<categoryDto, Category>();
            CreateMap<authorDto, Author>().ForMember(dest => dest.Books, act => act.MapFrom(src => src.Books));
        }
    }
}
