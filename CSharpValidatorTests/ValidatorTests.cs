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
        #region Bool

        [Test]
        public void ABoolArgument_ShouldPass_IfArgIsTrue()
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
        public void ABoolArgument_ShouldFail_IfArgIsFalse()
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
        public void ABoolLambda_ShouldPass_IfLambdaIsTrue()
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
        public void ABoolLambda_ShouldFaile_IfLambdaIsFalse()
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

            #endregion

        #region True/False

        [Test]
        public void IsTrueConstraint_ShouldPass_IfObjectIsTrue()
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
        public void IsTrueConstraint_ShouldFail_IfObjectIsFalse()
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
        public void IsFalseConstraint_ShouldPass_IfObjectIsFalse()
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
        public void IsFalseConstraint_ShouldFail_IfObjectIsTrue()
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

            #endregion

        #region Null/NotNull

        [Test]
        public void IsNullConstraint_ShouldPass_IfObjectIsNull()
        {
            // Act
            var validate = new V.Validate();
            validate.That((object)null, V.Is.Null, "Should be null");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void IsNullConstraint_ShouldFail_IfObjectIsNotNull()
        {
            // Act
            var validate = new V.Validate();
            validate.That("notnull", V.Is.Null, "Should be null");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Should be null"));
        }

        [Test]
        public void IsNotNullConstraint_ShouldPass_IfObjectIsNotNull()
        {
            // Act
            var validate = new V.Validate();
            validate.That("notnull", V.Is.NotNull, "Should be not null");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void IsNotNullConstraint_ShouldFail_IfObjectIsNull()
        {
            // Act
            var validate = new V.Validate();
            validate.That((object)null, V.Is.NotNull, "Should be not null");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Should be not null"));
        }

            #endregion

        #region NullOrWhiteSpace/NotNullOrWhitespace

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
        public void NullOrWhiteSpace_ShouldPass_IfObjectIsNullOrWhitespace(string arg)
        {
            // Act
            var validate = new V.Validate();
            validate.That(arg, V.Is.NullOrWhiteSpace, "Should be null or whitespace");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        [Test]
        public void NullOrWhiteSpace_ShouldFail_IfObjectIsNotWhitespace()
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
        public void NotNullOrWhiteSpace_ShouldFail_IfObjectIsNullOrWhitespace(string arg)
        {
            // Act
            var validate = new V.Validate();
            validate.That(arg, V.Is.NotNullOrWhiteSpace, "Should not be null or whitespace");

            // Assert
            Assert.That(validate.HasErrors, Is.True);
            Assert.That(validate.Errors[0].Message, Is.EqualTo("Should not be null or whitespace"));
        }

        [Test]
        public void NotNullOrWhiteSpace_ShouldPass_IfObjectIsNotWhitespace()
        {
            // Act
            var validate = new V.Validate();
            validate.That("   notwhitespace", V.Is.NotNullOrWhiteSpace, "Should not be null or whitespace");

            // Assert
            Assert.That(validate.HasErrors, Is.False);
        }

        #endregion

        // True/False
        // Null/NotNull
        // NullOrWhiteSpace/ NotNullOrWhiteSpace


    }
}