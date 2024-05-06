using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindModelClassLibrary;
using ProductsAPIService.Infrastructure;

namespace ProductsAPIService.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [Auth("admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }
        [HttpGet(template:"")]
        public IActionResult GetAllProducts() 
        {
            var model = _repository.GetAll(); 
            return Ok(model);
        }
        [HttpGet(template:"{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var model = _repository.GetById(id);
            if (model is not null)
            {
                return model;
            }
            else
                return NotFound();
        }


    }
}
