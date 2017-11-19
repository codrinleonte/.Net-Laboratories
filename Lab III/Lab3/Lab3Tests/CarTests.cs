using System;
using FluentAssertions;
using Lab3;
using LabIProject.Test;
using Xunit;

namespace Lab3Tests
{
    public class CarTest : BaseTest<Car>
    {
        private const string COLOR = "red";
        private const int HORSEPOWER = 200;
        private const int CONSUMPTION = 7;
        private const int NUMBEROFDOORS = 4;
        private const int TRUNKCAPACITY = 40;

        private const int GOOD_DISTANCE = 150;

        protected override Car SetupSystemUnderTest()
        {
            return Car.Create(COLOR, HORSEPOWER, CONSUMPTION, NUMBEROFDOORS, TRUNKCAPACITY);
        }

        [Fact]
        public void Given_ComputeFuelConsumption_WhenCalledWithGoodValue_Then_ShouldReturnGoodCalculation()
        {
            var correctResult = CONSUMPTION * GOOD_DISTANCE / 100;

            var result = SystemUnderTest.ComputeFuelConsumption(GOOD_DISTANCE);

            result.Should().Be(correctResult);
        }

        [Fact]
        public void Given_ComputeFuelConsumption_WhenCalledWithNegativeNumber_Then_ShouldThrowException()
        {
            Action result = () => { SystemUnderTest.ComputeFuelConsumption(-2); };

            result.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Given_ComputeFuelConsumption_WhenPassedZero_Then_ShouldThrowException()
        {
            Action result = () => { SystemUnderTest.ComputeFuelConsumption(0); };

            result.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Given_StartEngine_Should_ReturnStartingCar()
        {
            var result = SystemUnderTest.StartEngine();

            result.Should().Be("Starting Car");
        }

    }
}