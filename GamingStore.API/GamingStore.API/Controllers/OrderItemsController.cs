using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingStore.API.Models;
using GamingStore.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamingStore.API.Controllers
{
    [Route("api/[controller]")]
    public class OrderItemsController : BaseController
    {
        private readonly OrderItemsService _context;
        public OrderItemsController(OrderItemsService orderItemsService)
        {
            _context = orderItemsService;
        }

        [HttpGet]
        public async Task<List<OrderItems>> Get()
        {
            return await _context.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItems>> Get(string id)
        {
            var obj = await _context.Get(id);
            if (obj == null)
            {
                return NotFound();
            }
            return obj;
        }

        [HttpPost]
        public async Task<OrderItems> Post([FromBody]OrderItems cat)
        {
            return await _context.Create(cat);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody]OrderItems catIn)
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
