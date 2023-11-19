using core.entity;
using System.Text.Json;

namespace repo.data
{
    public class ContextSeed
    {
        public static async Task SeedAsync(Context context)
        {
            #region seed brand
            if (!context.ProductBrands.Any())
            {

                var brandData = File.ReadAllText("../repo/data/seed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                if (brands != null && brands.Count > 0)
                {
                    foreach (var item in brands)
                    {
                        await context.Set<ProductBrand>().AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            #endregion

            #region seed type
            if (!context.ProductTypes.Any())
            {

                var typeData = File.ReadAllText("../repo/data/seed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                if (types != null && types.Count > 0)
                {
                    foreach (var item in types)
                    {
                        await context.Set<ProductType>().AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            #endregion

            #region seed products
            if (!context.Products.Any())
            {

                var productData = File.ReadAllText("../repo/data/seed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                if (products != null && products.Count > 0)
                {
                    foreach (var item in products)
                    {
                        await context.Set<Product>().AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            #endregion

        }

    }
}
