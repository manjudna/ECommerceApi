using ECommerceApi.Data;
using ECommerceApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApi.Controllers
{
    public class DuplicateConfigValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var _context = (ECommerceApiContext)validationContext.GetService(typeof(ECommerceApiContext));
            var configuration = (Configuration)validationContext.ObjectInstance;


            if (_context.Configurations.ToList().Select(e => e.Name).ToList().Contains(configuration.Name))
            {
                return new ValidationResult("duplicate Configurations");
            }

            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }



    }
}
