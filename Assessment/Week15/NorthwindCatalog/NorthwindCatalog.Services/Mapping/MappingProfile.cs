using AutoMapper;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src =>
                        "/images/" + (src.CategoryName ?? "default")
                            .Replace(" ", "_")
                            .Replace("/", "_")
                            .Replace("\\", "_") + ".jpg"));

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.UnitPrice,
                    opt => opt.MapFrom(src => src.UnitPrice ?? 0))
                .ForMember(dest => dest.UnitsInStock,
                    opt => opt.MapFrom(src => src.UnitsInStock ?? (short)0));
        }
    }
}