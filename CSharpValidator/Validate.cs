using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpValidator
{
    public class Validate
    {
        private readonly List<ValidationError> errors = new List<ValidationError>();

        public void That(bool value, string message, string property = null)
        {
            if (value == false)
            {
                errors.Add(new ValidationError(message, property));
            }
        }
        public void That(Func<bool> lambda, string message, string property = null)
        {
            if (lambda() == false)
            {
                errors.Add(new ValidationError(message, property));
            }
        }

        public bool HasErrors => errors.Any();
        public IReadOnlyList<ValidationError> Errors => errors;
    }

    public class ValidationError
    {
        public ValidationError(string message, string property)
        {
            Message = message;
            Property = property;
        }
        public string Message { get; set; }
        public string Property { get; set; }
    }


}
