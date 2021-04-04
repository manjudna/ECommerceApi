using ECommerceApi.Models;
using System.ComponentModel.DataAnnotations;


namespace ECommerceApi.Controllers
{
    public class LaptopValidator: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var laptop = (Laptop)validationContext.ObjectInstance;

            if(string.IsNullOrEmpty(laptop.Name))
            {
                return new ValidationResult("name is null");
            }

            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }



    }

    
}
