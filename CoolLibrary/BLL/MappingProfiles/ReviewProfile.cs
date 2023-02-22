using AutoMapper;
using CoolLibrary.Common.DTO;
using CoolLibrary.Common.Entities;

namespace CoolLibrary.BLL.MappingProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, NewReviewDto>().ReverseMap();
        }
    }
}