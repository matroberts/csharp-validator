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

        [Test]
        public void Validate_IfABoolArgument_IsTrue_NoErrorIsRaised()
        {
            // Arrange
            var testObject = new { Flag = true };

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
            var testObject = new { Flag = false };

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
            var testObject = new { Name = "woot"};

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
            var testObject = new { Name = "wrong" };

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
            var testObject = new { Flag = true };

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
            var testObject = new { Flag = false };

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
            var testObject = new { Flag = false };

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
            var testObject = new { Flag = true };

            // Act
            var validate = new V.Validate();
            validate.That(testObject.Flag, V.Is.False, "Flag should be false");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Flag should be false"));
        }

	    [Test]
	    public void Validate_IsNullConstraint_ShouldReturnNoError_IfObjectIsNull()
	    {
		    // Act
		    var validate = new V.Validate();
		    validate.That((object)null, V.Is.Null, "Should be null");

		    // Assert
		    Assert.That(validate.HasErrors, Is.False);
	    }

		[Test]
	    public void Validate_IsNullConstraint_ShouldReturnError_IfObjectIsNotNull()
	    {
		    // Act
		    var validate = new V.Validate();
		    validate.That("notnull", V.Is.Null, "Should be null");

		    // Assert
		    Assert.That(validate.HasErrors, Is.True);
		    Assert.That(validate.Errors[0].Message, Is.EqualTo("Should be null"));
		}

	    [Test]
	    public void Validate_IsNotNullConstraint_ShouldReturnNoError_IfObjectIsNotNull()
	    {
		    // Act
		    var validate = new V.Validate();
		    validate.That("notnull", V.Is.NotNull, "Should be not null");

		    // Assert
		    Assert.That(validate.HasErrors, Is.False);
	    }

	    [Test]
	    public void Validate_IsNotNullConstraint_ShouldReturnError_IfObjectIsNull()
	    {
		    // Act
		    var validate = new V.Validate();
		    validate.That((object)null, V.Is.NotNull, "Should be not null");

		    // Assert
		    Assert.That(validate.HasErrors, Is.True);
		    Assert.That(validate.Errors[0].Message, Is.EqualTo("Should be not null"));
	    }

		// True/False
		// Null/NotNull
        // TrimmedNullOrEmpty/ NotTrimmedNullOrEmpty


	}
}