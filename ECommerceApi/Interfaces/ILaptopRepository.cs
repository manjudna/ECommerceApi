using ECommerceApi.DTO;
using ECommerceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApi.Interfaces
{
    public interface ILaptopRepository
    {
        Task<List<Laptop>> GetLaptops();

        Task<Laptop> AddLaptop(Laptop laptop);
    }

}
