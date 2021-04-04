using ECommerceApi.Data;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationsController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        // GET: api/<ConfigurationsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var configs = await _configurationService.GetConfigurations();
            return Ok(configs);
        }


        // POST api/<ConfigurationsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Post([FromBody] Configuration configuration)
        {
            var configAdded = await _configurationService.AddConfiguration(configuration);

            return Ok(configAdded);
        }

    }
}
