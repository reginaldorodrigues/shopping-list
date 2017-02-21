using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationException = ShoppingList.Common.Validation.ValidationException;

namespace ShoppingList.Common.Infrastructure
{
    public abstract class ServiceBase
    {
        protected virtual void ValidateModel(object value)
        {
            var validationContext = new ValidationContext(value, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(value, validationContext, validationResults, true);

            if (validationResults.Count > 0)
                throw new ValidationException(validationResults);
        }
    }
}