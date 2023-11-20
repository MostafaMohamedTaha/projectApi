using AutoMapper;
using core.entity;
using core.repo;
using core.specification;
using Microsoft.AspNetCore.Mvc;
using projectApi.Dto;
using projectApi.Error;

namespace projectApi.Controllers
{
    public class ProductsController : BaseController
    {
        #region params

        private readonly IGenericRepo<Product> productsRepo;
        private readonly IMapper mapper;
        #endregion

        #region ctor

        public ProductsController(IGenericRepo<Product> ProductsRepo, IMapper mapper)
        {
            productsRepo = ProductsRepo;
            this.mapper = mapper;
        }
        #endregion

        #region crud

        #region get all

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToDto>>> GetProducts()
        {
            //var products = await productsRepo.GetAllAsync();
            var spec = new ProductSpec();
            var products = await productsRepo.GetAllAsyncWithSpecs(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToDto>>(products));
        }
        #endregion

        #region get by id

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToDto>> GetProductById(int id)
        {
            var spec = new ProductSpec(id);
            var products = await productsRepo.GetByIdAsyncWithSpecs(spec);
            if (products == null) return NotFound(new ApiResponse(404));
            return Ok(mapper.Map<Product, ProductToDto>(products));
        }
        #endregion

        #endregion
    }
}
