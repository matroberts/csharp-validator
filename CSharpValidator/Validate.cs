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
            That(value, Iss.True, message, property);
        }
        public void That(Func<bool> lambda, string message, string property = null)
        {
            That(lambda(), Iss.True, message, property);
        }

        public void That<TActual>(TActual actual, IConstraint constraint, string message, string property = null)
        {
            if(constraint.Apply(actual) == false)
                errors.Add(new ValidationError(message, property));
        }

        public bool HasErrors => errors.Any();
        public IReadOnlyList<ValidationError> Errors => errors;
    }
}
