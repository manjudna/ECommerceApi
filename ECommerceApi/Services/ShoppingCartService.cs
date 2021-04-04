using AutoMapper;
using ECommerceApi.DTO;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IShoppingCartValidator _shoppingCartValidator;
        private readonly IMapper _mapper;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IMapper mapper,IShoppingCartValidator shoppingCartValidator)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
            _shoppingCartValidator = shoppingCartValidator;
        }

        public async Task<ShoppingCart> AddToCart(ShoppingCart shoppingCart)
        {
            if (!_shoppingCartValidator.IsShoppingCartValid(shoppingCart))
                throw new Exception("Shopping Cart already contains same configuration Laptop, please add different configuration" + shoppingCart);

            return await _shoppingCartRepository.AddToCart(shoppingCart);
        }

       
    }
}
