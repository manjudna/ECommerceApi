using ECommerceApi.Controllers;
using System.Collections.Generic;

namespace ECommerceApi.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        //[DuplicateValidator]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<Configuration> Configuration { get; set; }

    }

    
}

