using AutoMapper;
using core.entity;
using projectApi.Dto;

namespace projectApi.Helpers
{
    public class ProductPicture : IValueResolver<Product, ProductToDto, string>
    {
        private readonly IConfiguration con;

        public ProductPicture(IConfiguration con)
        {
            this.con = con;
        }
        public string Resolve(Product source, ProductToDto destination, string distMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{con["baseUrl"]}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
