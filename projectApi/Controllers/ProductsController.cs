using core.entity;
using core.repo;
using core.specification;
using Microsoft.AspNetCore.Mvc;

namespace projectApi.Controllers
{
    public class ProductsController : BaseController
    {
        #region params

        private readonly IGenericRepo<Product> productsRepo;
        #endregion

        #region ctor

        public ProductsController(IGenericRepo<Product> ProductsRepo)
        {
            productsRepo = ProductsRepo;
        }
        #endregion

        #region crud

        #region get all

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            //var products = await productsRepo.GetAllAsync();
            var spec = new ProductSpec();
            var products = await productsRepo.GetAllAsyncWithSpecs(spec);
            return Ok(products);
        }
        #endregion

        #region get by id

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new ProductSpec(id);
            var products = await productsRepo.GetByIdAsyncWithSpecs(spec);
            return Ok(products);
        }
        #endregion

        #endregion
    }
}
