using ECommerceApi.Data;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        

        // POST api/<ShoppingCartController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Post([FromBody] ShoppingCart shoppingCart)
        {
            var shoppingCartAdded = await _shoppingCartService.AddToCart(shoppingCart);

            return Ok(shoppingCartAdded);
        }

        
    }
}
