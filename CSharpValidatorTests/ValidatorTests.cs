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
        public void IfABoolArgument_IsTrue_NoErrorIsRaised()
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
        public void IfABoolArgument_IsFalse_AnErrorIsRaised()
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
        public void IfABoolLambda_IsTrue_NoErrorIsRaised()
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
        public void IfABoolLambda_IsFalse_AnErrorIsRaised()
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
        public void IsTrueConstraint_ShouldReturnNoError_IfObjectIsTrue()
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
        public void IsTrueConstraint_ShouldReturnError_IfObjectIsFalse()
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
        public void IsFalseConstraint_ShouldReturnNoError_IfObjectIsFalse()
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
        public void IsFalseConstraint_ShouldReturnError_IfObjectIsTrue()
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
	    public void IsNullConstraint_ShouldReturnNoError_IfObjectIsNull()
	    {
		    // Act
		    var validate = new V.Validate();
		    validate.That((object)null, V.Is.Null, "Should be null");

		    // Assert
		    Assert.That(validate.HasErrors, Is.False);
	    }

		[Test]
	    public void IsNullConstraint_ShouldReturnError_IfObjectIsNotNull()
	    {
		    // Act
		    var validate = new V.Validate();
		    validate.That("notnull", V.Is.Null, "Should be null");

		    // Assert
		    Assert.That(validate.HasErrors, Is.True);
		    Assert.That(validate.Errors[0].Message, Is.EqualTo("Should be null"));
		}

	    [Test]
	    public void IsNotNullConstraint_ShouldReturnNoError_IfObjectIsNotNull()
	    {
		    // Act
		    var validate = new V.Validate();
		    validate.That("notnull", V.Is.NotNull, "Should be not null");

		    // Assert
		    Assert.That(validate.HasErrors, Is.False);
	    }

	    [Test]
	    public void IsNotNullConstraint_ShouldReturnError_IfObjectIsNull()
	    {
		    // Act
		    var validate = new V.Validate();
		    validate.That((object)null, V.Is.NotNull, "Should be not null");

		    // Assert
		    Assert.That(validate.HasErrors, Is.True);
		    Assert.That(validate.Errors[0].Message, Is.EqualTo("Should be not null"));
	    }

        [Test]
        public void IsNullOrWhiteSpace_ShouldThrowException_IfActualIsNotAString()
        {
            // Arrange
            var testObj = new {Flag = false};

            // Act/Assert
            var validate = new V.Validate();
            Assert.That(() => validate.That(testObj.Flag, V.Is.NullOrWhiteSpace, "Should be trimmed null or empty"),
                            Throws.ArgumentException.With.Message.EqualTo("IsNullOrWhiteSpace can only be used with string type."));


        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void NullOrWhiteSpace_ShouldReturnNoError_IfObjectIsNull(string arg)
        {
            // Act
            var validate = new V.Validate();
            validate.That(arg, V.Is.NullOrWhiteSpace, "Should be null or whitespace");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void NullOrWhiteSpace_ShouldReturnError_IfObjectIsNotWhitespace()
        {
            // Act
            var validate = new V.Validate();
            validate.That("   notwhitespace", V.Is.NullOrWhiteSpace, "Should be null or whitespace");
        
            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Should be null or whitespace"));
        }

        [Test]
        public void IsNotNullOrWhiteSpace_ShouldThrowException_IfActualIsNotAString()
        {
            // Arrange
            var testObj = new { Flag = false };

            // Act/Assert
            var validate = new V.Validate();
            Assert.That(() => validate.That(testObj.Flag, V.Is.NotNullOrWhiteSpace, "Should not be null or whitespace"),
                Throws.ArgumentException.With.Message.EqualTo("IsNotNullOrWhiteSpace can only be used with string type."));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void NotNullOrWhiteSpace_ShouldReturnError_IfObjectIsNullOrWhitespace(string arg)
        {
            // Act
            var validate = new V.Validate();
            validate.That(arg, V.Is.NotNullOrWhiteSpace, "Should not be null or whitespace");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Should not be null or whitespace"));
        }

        [Test]
        public void NotNullOrWhiteSpace_ShouldReturnNoError_IfObjectIsNotWhitespace()
        {
            // Act
            var validate = new V.Validate();
            validate.That("   notwhitespace", V.Is.NotNullOrWhiteSpace, "Should not be null or whitespace");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        // True/False
        // Null/NotNull
        // NullOrWhiteSpace/ NotNullOrWhiteSpace


    }
}