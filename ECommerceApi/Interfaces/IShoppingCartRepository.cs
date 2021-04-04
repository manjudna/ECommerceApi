using ECommerceApi.DTO;
using ECommerceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApi.Interfaces
{
    public interface IShoppingCartRepository
    {
       Task<ShoppingCart> AddToCart(ShoppingCart laptop);
    }

}
