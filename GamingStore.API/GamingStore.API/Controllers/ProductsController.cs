using GamingStore.API.Models;
using GamingStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingStore.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly ProductsService _context;
        public ProductsController(ProductsService productsService)
        {
            _context = productsService;
        }

        [HttpGet]
        public async Task<List<Products>> Get()
        {
            return await _context.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> Get(string id)
        {
            var obj = await _context.Get(id);
            if (obj == null)
            {
                return NotFound();
            }
            return obj;
        }

        [Route("GetItemsByCategory")]
        [HttpGet("{id}")]
        public async Task<List<Products>> GetItemsByCategory(string id)
        {
            return await _context.GetByCategoryID(id);
        }

        [HttpPost]
        public async Task<Products> Post([FromBody]Products cat)
        {
            return await _context.Create(cat);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody]Products catIn)
        {
            var obj = _context.Get(id);
            if (obj == null)
            {
                return NotFound();
            }
            await _context.Update(id, catIn);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var obj = _context.Get(id);
            if (obj == null)
            {
                return NotFound();
            }
            await _context.Remove(id);
            return NoContent();
        }
    }
}
