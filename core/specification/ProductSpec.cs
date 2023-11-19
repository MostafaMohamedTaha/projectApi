using core.entity;

namespace core.specification
{
    public class ProductSpec : BaseSpecification<Product>
    {
        #region ctor
        public ProductSpec()
        {
            Includes.Add(x => x.ProductBrand);
            Includes.Add(x => x.ProductType);

        }
        public ProductSpec(int id) : base(x => x.Id == id)
        {
            Includes.Add(x => x.ProductBrand);
            Includes.Add(x => x.ProductType);
        }
        #endregion
    }
}
