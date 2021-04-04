using ECommerceApi.Data;
using ECommerceApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace ECommerceApi.Controllers
{
    public class DuplicateValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var _context = (ECommerceApiContext)validationContext.GetService(typeof(ECommerceApiContext));
            var laptop = (Laptop)validationContext.ObjectInstance;

            if (_context.Laptops.ToList().Select(e=>e.Name).ToList().Contains(laptop.Name))
            {
                return new ValidationResult("duplicate laptop");
            }

            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
    
}
