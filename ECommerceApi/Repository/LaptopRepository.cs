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
    public class LaptopRepository: ILaptopRepository
    {
        private readonly ECommerceApiContext _eCommerceApiContext;
      
        public LaptopRepository(ECommerceApiContext eCommerceApiContext)
        {
            _eCommerceApiContext = eCommerceApiContext;
           
        }

        public async Task<Laptop> AddLaptop(Laptop laptop)
        {           
            _eCommerceApiContext.Laptops.Add(laptop);
            await _eCommerceApiContext.SaveChangesAsync();
            return laptop;            
        }

        public async Task<List<Laptop>> GetLaptops()
        {
            var laptops = await _eCommerceApiContext.
               Laptops.Include(i => i.Configuration).
               ToListAsync();
                      

            return laptops;
        }

       
    }
}
