using AutoMapper;
using CoolLibrary.Common.DTO;
using CoolLibrary.Common.Entities;

namespace CoolLibrary.BLL.MappingProfiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDto>().ReverseMap();
        }
    }
}