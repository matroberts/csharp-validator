using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpValidator
{
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