using GamingStore.API.Models;
using GamingStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : BaseController
    {
        private readonly UsersService _context;
        public UsersController(UsersService usersService)
        {
            _context = usersService;
        }

        [HttpGet]
        public async Task<List<Users>> Get()
        {
            return await _context.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(string id)
        {
            var obj = await _context.Get(id);
            if (obj == null)
            {
                return NotFound();
            }
            return obj;
        }

        [HttpPost]
        public async Task<Users> Post([FromBody]Users cat)
        {
            return await _context.Create(cat);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody]Users catIn)
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
