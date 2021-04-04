using ECommerceApi.Models;

namespace ECommerceApi.Interfaces
{
    public interface IConfigurationValidator
    {
       bool IsConfigurationValid(Configuration configuration);
              
    }

}
