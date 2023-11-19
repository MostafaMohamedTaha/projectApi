using AutoMapper;
using core.entity;
using projectApi.Dto;

namespace projectApi.Helpers
{
    public class MappingProfile : Profile
    {
        #region ctor
        public MappingProfile()
        {
            CreateMap<Product, ProductToDto>()
                .ForMember(x => x.ProductBrand, x => x.MapFrom(x => x.ProductBrand.Name))
                .ForMember(x => x.ProductType, x => x.MapFrom(x => x.ProductType.Name))
                .ForMember(x => x.PictureUrl, x => x.MapFrom<ProductPicture>());
        }
        #endregion
    }
}
