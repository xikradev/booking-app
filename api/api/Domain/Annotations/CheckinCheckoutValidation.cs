using api.Domain.Dto.Request;
using System.ComponentModel.DataAnnotations;

namespace api.Domain.Annotations
{
    public class CheckinCheckoutValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var place = (PlaceRequest)validationContext.ObjectInstance;

            if(place.CheckIn > place.CheckOut)
            {
                return new ValidationResult("A data de checkin não pode ser maior que a data de checkout.");
            }

            if(place.CheckIn > DateTime.Now)
            {
                return new ValidationResult("A data de checkin deve ser menor ou igual à data atual.");
            }

            if(place.CheckOut <= DateTime.Now)
            {
                return new ValidationResult("A data de checkout deve ser maior que a data atual.");
            }

            return ValidationResult.Success;
        }
    }
}
