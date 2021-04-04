using ECommerceApi.Controllers;
using ECommerceApi.DTO;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace ECommerceXUnitTests
{
    public class ConfigurationsUnitTests
    {
        ConfigurationsController _controller;
        IConfigurationService _laptopService;

        public ConfigurationsUnitTests()
        {
            _laptopService = new ECommerceConfigDataFake();
            _controller = new ConfigurationsController(_laptopService);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Xunit.Assert.IsType<List<ConfigurationDTO>>(okResult.Value);

            Assert.Equal(2, items.Count);
        }


        [Fact]
        public void Add_WhenCalled_ReturnsAddedConfig()
        {
            Configuration configuration = new Configuration();


            configuration.configugurationEnumType = ConfigugurationEnum.RAM;
            configuration.Price = 50;
            configuration.Name = "16 GB";
            configuration.Id = 1;
            
            var okResult = _controller.Post(configuration).Result as OkObjectResult;
            // Assert
            var configAdded = Xunit.Assert.IsType<Configuration>(okResult.Value);

            Assert.NotNull(configAdded);
        }



    }
}
