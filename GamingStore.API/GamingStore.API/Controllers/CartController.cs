using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingStore.API.DTO;
using GamingStore.API.Models;
using GamingStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseController
    {
        private readonly CartService _context;
        public CartController(CartService context)
        {
            _context = context;
        }

        [HttpGet]
        public List<string> Get()
        {
            List<string> abc = new List<string>();
            abc.Add("Alpha");
            return abc.ToList();
        }

        [Route("AddToCart")]
        [HttpPost]
        public async Task<Orders> AddToCart([FromBody]AddToCartDTO obj)
        {
            return await _context.AddToCart(obj.prodID,obj.quantity,obj.price,obj.sessionID,obj.cstID);
        }

    }
}