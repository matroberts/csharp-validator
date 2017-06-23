
namespace CSharpValidator
{
    public class Is
    {
        public static TrueConstraint True => new TrueConstraint();
        public static FalseConstraint False => new FalseConstraint();
	    public static NullConstraint Null =>  new NullConstraint();
	    public static NotNullConstraint NotNull =>  new NotNullConstraint();
    }



	public interface IConstraint
    {
        bool Apply<TActual>(TActual actual);
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