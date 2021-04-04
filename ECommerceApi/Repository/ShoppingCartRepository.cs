using AutoMapper;
using ECommerceApi.Data;
using ECommerceApi.DTO;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ECommerceApiContext _eCommerceApiContext;
      
        public ShoppingCartRepository(ECommerceApiContext eCommerceApiContext)
        {
            _eCommerceApiContext = eCommerceApiContext;
           
        }

        public async Task<ShoppingCart> AddToCart(ShoppingCart shoppingCart)
        {           
            _eCommerceApiContext.ShoppingCarts.Add(shoppingCart);
            await _eCommerceApiContext.SaveChangesAsync();
            return shoppingCart;
            
        }
             

       
    }
}
