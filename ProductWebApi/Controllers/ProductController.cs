using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Data;
using ProductWebApi.Model;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public ActionResult<Product> Create([FromBody] Product product)
        {
            var result = _dbContext.Products.
                AsQueryable().Where(x =>x.Name.ToLower().Trim() == product.Name.ToLower().Trim()).Any();

            if (result)
            {
                return Conflict("Product Already Exists in Database");
            }

            _dbContext.Add(product);
            _dbContext.SaveChanges();
            return CreatedAtAction("GetByID", new { id = product.Id }, product);

            //_dbContext.Add(product);
            //_dbContext.SaveChanges();
            //return Ok(product);        
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Product> GetByID(int Id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == Id);
            if (product == null)
            {
                return NoContent();
            }
            return product;

        }

    }
}
