using AutoMapper;
using ECommerceApi.DTO;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Services
{
    public class ConfigurationService: IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;
        private readonly IConfigurationValidator _configurationValidator;
        public ConfigurationService(IConfigurationRepository configurationRepository,IMapper mapper, IConfigurationValidator configurationValidator)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
            _configurationValidator = configurationValidator;
        }

        public async Task<Configuration> AddConfiguration(Configuration configuration)
        {
            if (!_configurationValidator.IsConfigurationValid(configuration))
                throw new Exception("Configuration with same details found, please add different configuration" + configuration);
         
            return await _configurationRepository.AddConfiguration(configuration);

        }

       
        public async Task<List<ConfigurationDTO>> GetConfigurations()
        {
            var configs = await _configurationRepository.GetConfigurations();
            var configurationDTOs = _mapper.Map<List<ConfigurationDTO>>(configs);
            return configurationDTOs;
        }

       
    }
}
