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
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ECommerceApiContext _eCommerceApiContext;
       
        public ConfigurationRepository(ECommerceApiContext eCommerceApiContext)
        {
            _eCommerceApiContext = eCommerceApiContext;
           
        }

        public async Task<Configuration> AddConfiguration(Configuration configuration)
        {
                       
            _eCommerceApiContext.Configurations.Add(configuration);
            await _eCommerceApiContext.SaveChangesAsync();
            return configuration;
            
        }

        public async Task<List<Configuration>> GetConfigurations()
        {
            var configurations = await _eCommerceApiContext.
               Configurations.
               ToListAsync();           

            return configurations;
        }

       
    }
}
