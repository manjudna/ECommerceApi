using ECommerceApi.Data;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Services
{
    public class ConfigValidator : IConfigurationValidator
    {
        private readonly ECommerceApiContext _eCommerceApiContext;

        public ConfigValidator(ECommerceApiContext eCommerceApiContext)
        {
            _eCommerceApiContext = eCommerceApiContext;
        }

        public bool IsConfigurationValid(Configuration configuration)
        {

            foreach (var existingConfiguration in _eCommerceApiContext.Configurations)
            {
                if (existingConfiguration.Name == configuration.Name
                                        && existingConfiguration.configugurationEnumType == (ConfigugurationEnum)configuration.configugurationEnumType
                                        && existingConfiguration.Price == configuration.Price)
                    return false;
            }
            
            

            return true;
        }
    }
}
