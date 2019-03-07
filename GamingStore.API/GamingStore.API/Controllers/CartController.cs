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
        private readonly CartService _cartService;
        private readonly ProductsService _productService;

        public CartController(CartService context,ProductsService productsService)
        {
            _cartService = context;
            _productService = productsService;
        }

        [HttpGet]
        public List<string> Get()
        {
            List<string> abc = new List<string>();
            abc.Add("Alpha");
            return abc.ToList();
        }

        [Route("GetOrderBySessionId")]
        [HttpGet]
        public async Task<ActionResult<CartDTO>> GetOrderBySessionId(string sessionId)
        {
            var order = await _cartService.GetBySessionId(sessionId);
            if (order == null)
            {
                return NotFound();
            }

            //Mapping Orders to CartDTO Object
            CartDTO cartDTO = new CartDTO()
            {
                customerID = order.customerID,
                date = order.date,
                orderID = order.orderID,
                total = order.total,
                cartItem = order.items.Select(d => new CartItemDTO { prodID = d.prodID, quantity = d.quantity }).ToList()
            };

            //Attaching Products to CartDto
            foreach (CartItemDTO itemDTO in cartDTO.cartItem)
            {
                itemDTO.product = await _productService.Get(itemDTO.prodID);
            }

            return cartDTO;
        }

        [Route("AddToCart")]
        [HttpPost]
        public async Task<Orders> AddToCart([FromBody]AddToCartDTO obj)
        {
            return await _cartService.AddToCart(obj.prodID, obj.quantity, obj.price, obj.sessionID, obj.cstID);
        }

    }
}