using ECommerceApi.DTO;
using ECommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Interfaces
{
    public interface ILaptopService
    {
        Task<List<LaptopDTO>> GetLaptops();

        Task<Laptop> AddLaptop(Laptop laptop);
    }

}
