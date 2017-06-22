﻿using System.Security.Cryptography.X509Certificates;

namespace CSharpValidator
{
    public class Iss
    {
        public static TrueConstraint True => new TrueConstraint();
        public static FalseConstraint False => new FalseConstraint();
    }

    public interface IConstraint
    {
        bool Apply<TActual>(TActual actual);
    }

    public class TrueConstraint : IConstraint
    {
        public bool Apply<TActual>(TActual actual)
        {
            return true.Equals(actual);
        }
    }

    public class FalseConstraint : IConstraint
    {
        public bool Apply<TActual>(TActual actual)
        {
            return false.Equals(actual);
        }
    }
}