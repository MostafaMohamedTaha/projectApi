using Microsoft.AspNetCore.Mvc;
using projectApi.Error;
using repo.data;

namespace projectApi.Controllers
{

    public class BugController : BaseController
    {
        #region params

        private readonly Context _context;
        #endregion

        #region ctor
        public BugController(Context context)
        {
            this._context = context;
        }
        #endregion

        #region methods not found
        [HttpGet("notFound")]
        public ActionResult GetNotFound()
        {
            var products = _context.Products.Find(100000);
            if (products == null) { return NotFound(new ApiResponse(404)); }
            return Ok(products);
        }
        #endregion

        #region methods serverError
        [HttpGet("serverError")]
        public ActionResult GetServerError()
        {
            var products = _context.Products.Find(100000);
            var productToReturn = products.ToString(); //null reference
            return Ok(productToReturn);
        }
        #endregion

        #region methods badRequest
        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        #endregion

        #region methods badRequest Id
        [HttpGet("badRequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
        #endregion

    }
}