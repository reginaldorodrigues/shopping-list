using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShoppingList.Common.Validation
{
    public class ValidationException : Exception
    {
        public ICollection<ValidationResult> Errors { get; private set; }

        public ValidationException(string message)
            : base(message)
        {
            Errors = new ReadOnlyCollection<ValidationResult>(new List<ValidationResult>());
        }

        public ValidationException(ValidationResult validationResult)
            : this(new[] { validationResult })
        {
        }

        public ValidationException(ICollection<ValidationResult> validationResults)
            : base("The model contains validation errors")
        {
            Errors = new ReadOnlyCollection<ValidationResult>(validationResults.ToList());
        }
    }
}