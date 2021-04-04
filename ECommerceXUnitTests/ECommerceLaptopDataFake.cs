using ECommerceApi.DTO;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceXUnitTests
{
    public class ECommerceLaptopDataFake : ILaptopService
    {
        List<LaptopDTO> laptops = new List<LaptopDTO>();
        List<Laptop> laptopToAdd = new List<Laptop>();
        public ECommerceLaptopDataFake()
        {
            laptops.Add(new LaptopDTO { Id = 1, Name = "Dell" });
            laptops.Add(new LaptopDTO { Id = 2, Name = "Sony" });

        }

        public Task<Laptop> AddLaptop(Laptop laptop)
        {
            laptopToAdd.Add(laptop);

            // Task.FromResult(laptop);

            return Task.FromResult(laptop);
        }

        public Task<List<LaptopDTO>> GetLaptops()
        {
            return Task.FromResult(laptops);
        }
    }

    public class ECommerceShoppingCartDataFake : IShoppingCartService
    {
        List<ShoppingCart> shoppingCartsToAdd = new List<ShoppingCart>();
        public ECommerceShoppingCartDataFake()
        {
            shoppingCartsToAdd.Add(new ShoppingCart { Id = 1, Laptops = new List<Laptop> {
                new Laptop{ Id=1, Name= "Dell", Price= 560}
            } });
            shoppingCartsToAdd.Add(new ShoppingCart
            {
                Id = 2,
                Laptops = new List<Laptop> {
                new Laptop{ Id=2, Name= "IBM", Price= 500}
            }
            });

        }


        public Task<ShoppingCart> AddToCart(ShoppingCart shoppingCart)
        {
            shoppingCartsToAdd.Add(shoppingCart);

            // Task.FromResult(laptop);

            return Task.FromResult(shoppingCart);
        }

    }
}
