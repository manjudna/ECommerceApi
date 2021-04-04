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
    public class LaptopUnitTests
    {
        LaptopController _controller;
        ILaptopService _laptopService;

        public LaptopUnitTests()
        {
            _laptopService = new ECommerceLaptopDataFake();
            _controller = new LaptopController(_laptopService);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Xunit.Assert.IsType<List<LaptopDTO>>(okResult.Value);

            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void Add_WhenCalled_ReturnsAddedLaptop()
        {
            Laptop laptop = new Laptop();
            laptop.Id = 1;
            laptop.Name = "Sony";
            laptop.Price = 600;
            laptop.Configuration = new List<Configuration> 
            {
                 new Configuration
                 {
                     configugurationEnumType= ConfigugurationEnum.RAM,
                     Price=50,
                     Name= "16 GB",
                     Id = 1
                 },
                 new Configuration
                 {
                     configugurationEnumType= ConfigugurationEnum.Colour,
                     Price=30,
                     Name= "Blue",
                     Id = 2
                 },
                 new Configuration
                 {
                     configugurationEnumType= ConfigugurationEnum.HDD,
                     Price=60,
                     Name= "1 TB",
                     Id = 3
                 },

            };
            var okResult = _controller.Post(laptop).Result as OkObjectResult;
            // Assert
            var laptopadded = Xunit.Assert.IsType<Laptop>(okResult.Value);

            Assert.NotNull(laptopadded);
        }


    }
}
