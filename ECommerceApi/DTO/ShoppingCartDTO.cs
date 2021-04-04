using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.DTO
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public List<LaptopDTO> Laptops { get; set; }
    }
}
