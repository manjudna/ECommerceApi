using ECommerceApi.Controllers;


namespace ECommerceApi.Models
{

    public class Configuration
    {
        public int Id { get; set; }

        public  ConfigugurationEnum configugurationEnumType { get; set; }

      
        public string Name { get; set; }

        public decimal Price { get; set; }

    }
   


}
