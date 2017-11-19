using System;
using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests
{
    [TestClass]
    public class StringServiceTests
    {
        [TestMethod]
        public void When_IsPalindromeCallledWithInputRotator_ThenShouldReturn_True()
        {
            // Arrange
            var input = "rotator";

            // Act
            var isPalindome = input.IsPalindome();
            //Assert
            Assert.IsTrue(isPalindome);
        }

        [TestMethod]
        public void When_IsPalindromeCallledWithInputRotator1_ThenShouldReturn_False()
        {
            // Arrange
            var input = "rotator1";

            // Act
            var isPalindome = input.IsPalindome();

            //Assert
            Assert.IsFalse(isPalindome);
        }

        [TestMethod]
        public void When_ConcatenateCalledWithNotEmptyArgument_ThenShould_ReturnConcatenateStrings()
        {
            var values = new[] {"rotator", "capac"};

            var result = StringService.Concatenate(values);

            Assert.IsTrue(result == "rotatorcapac");
        }


        [TestMethod]
        public void When_ConcatenateCalledWithEmptyArgument_ThenShould_ReturnEmptyArray()
        {
          

            var result = StringService.Concatenate();

            Assert.IsTrue(result == "");
        }
    }
}