using ECommerceApi.Controllers;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit;
using Assert = Xunit.Assert;

namespace ECommerceApi.Tests
{
    
    public class LaptopUnitTest
    {

        LaptopController _controller;
        ILaptopService _laptopService;

        public LaptopUnitTest()
        {
            _laptopService = new ECommerceDataFake();
            _controller = new LaptopController(_laptopService);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Xunit.Assert.IsType<List<Laptop>>(okResult.Value);

            Assert.Equal(2, items.Count);
        }
    }
}
