using ecom.Data;
using ecom.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
                _context = context; 
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
