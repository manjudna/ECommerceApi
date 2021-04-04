using ECommerceApi.DTO;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceXUnitTests
{
    public class ECommerceConfigDataFake : IConfigurationService
    {
        List<ConfigurationDTO> configurationDTOs = new List<ConfigurationDTO>();
        List<Configuration> configsToAdd = new List<Configuration>();
        public ECommerceConfigDataFake()
        {
            configurationDTOs.Add(new ConfigurationDTO { Id = 1, Name = "1 TB", Price= 90, configugurationEnumType=ConfigugurationEnumDTO.HDD });
            configurationDTOs.Add(new ConfigurationDTO { Id = 2, Name = "Blue", Price= 40, configugurationEnumType= ConfigugurationEnumDTO.Colour });

        }

        public Task<Configuration> AddConfiguration(Configuration configuration)
        {
            configsToAdd.Add(configuration);
            return Task.FromResult(configuration);
        }

        

        public Task<List<ConfigurationDTO>> GetConfigurations()
        {
            return Task.FromResult(configurationDTOs);
        }

        
    }
}
