using ECommerceApi.Models;

namespace ECommerceApi.Interfaces
{
    public interface IShoppingCartValidator
    {
        bool IsShoppingCartValid(ShoppingCart configuration);

    }


}
