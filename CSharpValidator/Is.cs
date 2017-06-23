
using System;

namespace CSharpValidator
{
    public class Is<TActual>
    {
        public  TrueConstraint True => new TrueConstraint();
        public  FalseConstraint False => new FalseConstraint();
	    public  NullConstraint Null => new NullConstraint();
	    public  NotNullConstraint NotNull => new NotNullConstraint();
	    public  NullOrWhiteSpaceConstraint NullOrWhiteSpace => new NullOrWhiteSpaceConstraint();
	    public  NotNullOrWhiteSpaceConstraint NotNullOrWhiteSpace => new NotNullOrWhiteSpaceConstraint();
	    public  LengthLessThanOrEqualToConstraint LengthLessThanOrEqualTo(int length) => new LengthLessThanOrEqualToConstraint(length);
    }

	public interface IConstraint
    {
        bool Apply<TActual>(TActual actual);
    }

    public class LengthLessThanOrEqualToConstraint : IConstraint
    {
        private readonly int length;
        public LengthLessThanOrEqualToConstraint(int length)
        {
            this.length = length;
        }
        public bool Apply<TActual>(TActual actual)
        {
            if (actual == null)
            {
                return true;
            }
            if ((object)actual is string str)
            {
                return str.Length <= length;
            }
            throw new ArgumentException("LengthLessThanOrEqualTo can only be used with string type.");
        }
    }

    public class NotNullOrWhiteSpaceConstraint : IConstraint
    {
        public bool Apply<TActual>(TActual actual)
        {
            if (actual == null)
            {
                return false;
            }
            if ((object)actual is string str)
            {
                return string.IsNullOrWhiteSpace(str) == false;
            }
            throw new ArgumentException("IsNotNullOrWhiteSpace can only be used with string type.");
        }
    }

    public class NullOrWhiteSpaceConstraint : IConstraint
    {
        public bool Apply<TActual>(TActual actual)
        {
            if (actual == null)
            {
                return true;
            }
            if ((object)actual is string str)
            {
                return string.IsNullOrWhiteSpace(str);
            }
            throw new ArgumentException("IsNullOrWhiteSpace can only be used with string type.");
        }
    }
    public class NullConstraint : IConstraint
	{
		public bool Apply<TActual>(TActual actual) => actual == null;
	}

	public class NotNullConstraint : IConstraint
	{
		public bool Apply<TActual>(TActual actual) => actual != null;
	}

	public class TrueConstraint : IConstraint
    {
        public bool Apply<TActual>(TActual actual) => true.Equals(actual);
    }

    public class FalseConstraint : IConstraint
    {
        public bool Apply<TActual>(TActual actual) => false.Equals(actual);
    }
}