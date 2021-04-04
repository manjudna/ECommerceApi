using ECommerceApi.DTO;
using ECommerceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApi.Interfaces
{
    public interface IConfigurationService
    {
        Task<List<ConfigurationDTO>> GetConfigurations();

        Task<Configuration> AddConfiguration(Configuration laptop);
    }



}
