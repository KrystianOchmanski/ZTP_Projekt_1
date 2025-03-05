using AutoMapper;
using ZTP_Projekt_1.Domain;
using ZTP_Projekt_1.Web.DTOs.CategoryDTOs;

namespace ZTP_Projekt_1.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<EditCategoryDTO, Category>();
        }
    }
}
