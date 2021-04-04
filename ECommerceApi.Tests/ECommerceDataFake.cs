using ECommerceApi.DTO;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Tests
{
    public class ECommerceDataFake : ILaptopService
    {
        List<LaptopDTO> laptops = new List<LaptopDTO>();
        List<Laptop> laptopToAdd = new List<Laptop>();
        public ECommerceDataFake()
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
}
