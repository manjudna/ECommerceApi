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
    public class LaptopValidator : ILaptopValidator
    {
        private readonly ECommerceApiContext _eCommerceApiContext;

        public LaptopValidator(ECommerceApiContext eCommerceApiContext)
        {
            _eCommerceApiContext = eCommerceApiContext;
        }

        public bool IsLaptopValid(Laptop laptop)
        {
            var existingLaptops = _eCommerceApiContext.Laptops.Include(c=>c.Configuration).ToList();

            if (laptop.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.HDD).ToList().Count > 1
                     || laptop.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.Colour).ToList().Count > 1
                     || laptop.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.RAM).ToList().Count > 1)
                throw new Exception("Configuration already added for the same type");

            var hdds = laptop.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.HDD).ToList();
            var colours = laptop.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.Colour).ToList();
            var rams = laptop.Configuration.Where(e => e.configugurationEnumType == ConfigugurationEnum.RAM).ToList();

            if (hdds.Count==0 || colours.Count==0 || rams.Count ==0)
                throw new Exception("Please add atleast one configuration for Laptop ie. RAM, Colour and HDD..");
                

            foreach (var existingLaptop in existingLaptops)
            {
                if (existingLaptop.Name == laptop.Name && existingLaptop.Price == laptop.Price)
                    return false;

                    foreach (var econfiguration in existingLaptop.Configuration)
                    {

                        foreach (var lconfiguration in laptop.Configuration)
                        {
                            if (econfiguration.Name == lconfiguration.Name
                                         && econfiguration.configugurationEnumType == (ConfigugurationEnum)lconfiguration.configugurationEnumType
                                         && econfiguration.Price == lconfiguration.Price)
                                return false;
                        }

                        
                    }
                    
                
            }
                       

            return true;
        }
    }
}
