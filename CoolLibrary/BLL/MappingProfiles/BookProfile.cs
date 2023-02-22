using AutoMapper;
using CoolLibrary.Common.DTO;
using CoolLibrary.Common.Entities;

namespace CoolLibrary.BLL.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Rating, act => act.MapFrom(src => src.Ratings.Select(s => s.Score).DefaultIfEmpty(0).Average()));

            CreateMap<Book, BookPreviewDto>()
                .ForMember(dest => dest.Rating, act => act.MapFrom(src => src.Ratings.Select(s => s.Score).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.ReviewsNumber, act => act.MapFrom(src => src.Reviews.Count));

            CreateMap<Book, NewBookDto>().ReverseMap();
        }
    }
}