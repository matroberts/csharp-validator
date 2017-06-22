using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using V = CSharpValidator;

namespace CSharpValidatorTests
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
        public void Validate_IfABoolArgument_IsTrue_NoErrorIsRaised()
        {
            // Arrange
            var testObject = new TestObject() { Flag = true };

            // Act
            var validate = new V.Validate();
            validate.That(testObject.Flag, "Flag should be true");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void Validate_IfABoolArgument_IsFalse_AnErrorIsRaised()
        {
            // Arrange
            var testObject = new TestObject() { Flag = false };

            // Act
            var validate = new V.Validate();
            validate.That(testObject.Flag, "Flag should be true");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Flag should be true"));
        }

        [Test]
        public void Validate_IfABoolLambda_IsTrue_NoErrorIsRaised()
        {
            // Arrange
            var testObject = new TestObject() { Name = "woot"};

            // Act
            var validate = new V.Validate();
            validate.That(() => testObject.Name=="woot", "Name should be woot");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void Validate_IfABoolLambda_IsFalse_AnErrorIsRaised()
        {
            // Arrange
            var testObject = new TestObject() { Name = "wrong" };

            // Act
            var validate = new V.Validate();
            validate.That(() => testObject.Name == "woot", "Name should be woot");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Name should be woot"));
        }

        [Test]
        public void Validate_IsTrueConstraint_ShouldReturnNoError_IfObjectIsTrue()
        {
            // Arrange
            var testObject = new TestObject() { Flag = true };

            // Act
            var validate = new V.Validate();
            validate.That(testObject.Flag, V.Is.True, "Flag should be true");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void Validate_IsTrueConstraint_ShouldReturnError_IfObjectIsFalse()
        {
            // Arrange
            var testObject = new TestObject() { Flag = false };

            // Act
            var validate = new V.Validate();
            validate.That(testObject.Flag, V.Is.True, "Flag should be true");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Flag should be true"));
        }

        [Test]
        public void Validate_IsFalseConstraint_ShouldReturnNoError_IfObjectIsFalse()
        {
            // Arrange
            var testObject = new TestObject() { Flag = false };

            // Act
            var validate = new V.Validate();
            validate.That(testObject.Flag, V.Is.False, "Flag should be false");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void Validate_IsFalseConstraint_ShouldReturnError_IfObjectIsTrue()
        {
            // Arrange
            var testObject = new TestObject() { Flag = true };

            // Act
            var validate = new V.Validate();
            validate.That(testObject.Flag, V.Is.False, "Flag should be false");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Flag should be false"));
        }
    }
}