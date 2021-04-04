using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopService _laptopService;

        public LaptopController(ILaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        // GET: api/<LaptopController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var laptops = await _laptopService.GetLaptops();

            return Ok(laptops);
        }


        // POST api/<LaptopController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] Laptop laptop)
        {
            var laptopadded = await _laptopService.AddLaptop(laptop);
            return Ok(laptopadded);
        }

    }

    
}
