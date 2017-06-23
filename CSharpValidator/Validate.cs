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
            That(value, Is => Is.True, message, property);
        }
        public void That(Func<bool> lambda, string message, string property = null)
        {
            That(lambda(), Is => Is.True, message, property);
        }

        public void That<TActual>(TActual actual, Func<Is<TActual>, IConstraint> constraintExpression, string message, string property = null)
        {
            var constraint = constraintExpression(new Is<TActual>());

            if (constraint.Apply(actual) == false)
                errors.Add(new ValidationError(message, property));
        }

        public bool HasErrors => errors.Any();
        public IReadOnlyList<ValidationError> Errors => errors;
    }
}
