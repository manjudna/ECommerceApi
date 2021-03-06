using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.DTO
{
    public class LaptopDTO
    {
        public int Id { get; set; }

       // [DuplicateValidator]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<ConfigurationDTO> Configuration { get; set; }
    }
}
