using GamingStore.API.Models;
using GamingStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace GamingStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : BaseController
    {
        private readonly CategoryService _context;
        public CategoriesController(CategoryService categoryService)
        {
            _context = categoryService;
        }

        [HttpGet]
        public async Task<List<Categories>> Get()
        {
            return await _context.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> Get(string id)
        {
            var obj = await _context.Get(id);
            if (obj == null)
            {
                return NotFound();
            }
            return obj;
        }

        [HttpPost]
        public async Task<Categories> Post([FromBody]Categories cat)
        {
            return await _context.Create(cat);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody]Categories catIn)
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
