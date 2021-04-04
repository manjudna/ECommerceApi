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
    public class ShoppingCartUnitTests
    {
        ShoppingCartController _controller;
        IShoppingCartService _shoppingCartService;

        public ShoppingCartUnitTests()
        {
            _shoppingCartService = new ECommerceShoppingCartDataFake();
            _controller = new ShoppingCartController(_shoppingCartService);
        }



        [Fact]
        public void Add_WhenCalled_ReturnsAddedCart()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Id = 1;
            shoppingCart.Laptops = new List<Laptop>
            {
                new Laptop
                {
                    Id=2,
                    Name="HP",
                    Price =900,
                    Configuration = new List<Configuration>
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
                 }
                    }
                }
            };
            
            var okResult = _controller.Post(shoppingCart).Result as OkObjectResult;
            // Assert
            var shoppingCartAdded = Xunit.Assert.IsType<ShoppingCart>(okResult.Value);

            Assert.NotNull(shoppingCartAdded);
        }


    }
}
