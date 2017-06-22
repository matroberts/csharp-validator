using System;
using System.Linq;
using NUnit.Framework;

namespace CSharpValidator
{
    [TestFixture]
    public class ValidatorTests
    {
        /*var validate = new Validator();

        validate.That(object.Propert, Is.GreathT().And..., "Must be greathan", "proper");
var object = new object ();
validate.That(() => object.Property,  Is.GreathT().And..., "Must be greathan");

validate.ErroMessages();*/
        public class TestObject
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public bool Flag { get; set; }
        }

        [Test]
        public void Validate_IfABoolArgumentIsTrue_NoErrorIsRaised()
        {
            // Arrange
            var testObject = new TestObject() { Flag = true };

            // Act
            var validate = new Validate();
            validate.That(testObject.Flag, "Flag should be true");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void Validate_IfABoolArgumentIsFalse_AnErrorIsRaised()
        {
            // Arrange
            var testObject = new TestObject() { Flag = false };

            // Act
            var validate = new Validate();
            validate.That(testObject.Flag, "Flag should be true");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Flag should be true"));
        }

        [Test]
        public void Validate_IfABoolLambdaIsTrue_NoErrorIsRaised()
        {
            // Arrange
            var testObject = new TestObject() { Name = "woot"};

            // Act
            var validate = new Validate();
            validate.That(() => testObject.Name=="woot", "Name should be woot");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void Validate_IfABoolLambdatIsFalse_AnErrorIsRaised()
        {
            // Arrange
            var testObject = new TestObject() { Name = "wrong" };

            // Act
            var validate = new Validate();
            validate.That(() => testObject.Name == "woot", "Name should be woot");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Name should be woot"));
        }
    }
}