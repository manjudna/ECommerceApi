using ECommerceApi.DTO;
using ECommerceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApi.Interfaces
{
    public interface IConfigurationRepository
    {
        Task<List<Configuration>> GetConfigurations();

        Task<Configuration> AddConfiguration(Configuration laptop);
    }

}
