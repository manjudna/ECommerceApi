using ECommerceApi.Data;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Services
{
    public class ShoppingCartValidator : IShoppingCartValidator
    {
        private readonly ECommerceApiContext _eCommerceApiContext;

        public ShoppingCartValidator(ECommerceApiContext eCommerceApiContext)
        {
            _eCommerceApiContext = eCommerceApiContext;
        }

        public bool IsShoppingCartValid(ShoppingCart shoppingCart)
        {

            var existingShoppingCart = _eCommerceApiContext.ShoppingCarts.Include(i => i.Laptops).ThenInclude(c => c.Configuration).ToList();

            var existingLaptops = existingShoppingCart.Select(l => l.Laptops);

            foreach (var lapTopAddedToCart in shoppingCart.Laptops)
            {

                if (lapTopAddedToCart.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.HDD).ToList().Count > 1
                     || lapTopAddedToCart.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.Colour).ToList().Count > 1
                     || lapTopAddedToCart.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.RAM).ToList().Count > 1)
                    throw new Exception("Configuration already added for the same type");

                var hdds = lapTopAddedToCart.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.HDD).ToList().Count;
                var colours = lapTopAddedToCart.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.Colour).ToList().Count;
                var rams = lapTopAddedToCart.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.HDD).ToList().Count;

                if ( hdds==0 || colours==0 || rams==0)
                    throw new Exception("Please add atleast one configuration for Laptop ie. RAM, Colour and HDD..");


                foreach (var existingLaptopList in existingLaptops)
                {
                    foreach (var existingLaptop in existingLaptopList)
                    {
                        if (existingLaptop.Name == lapTopAddedToCart.Name && existingLaptop.Price == lapTopAddedToCart.Price)
                        {
                            foreach (var econfiguration in existingLaptop.Configuration)
                            {
                                foreach (var cconfiguration in lapTopAddedToCart.Configuration)
                                {
                                    if (cconfiguration.Name == econfiguration.Name
                                        && cconfiguration.configugurationEnumType == (ConfigugurationEnum)econfiguration.configugurationEnumType
                                        && cconfiguration.Price == econfiguration.Price)
                                        return false;
                                }
                            }

                        }

                    }

                }

            }
            return true;
        }
    }
}