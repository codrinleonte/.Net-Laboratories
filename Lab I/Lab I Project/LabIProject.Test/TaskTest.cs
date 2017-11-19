using System;
using FluentAssertions;
using Xunit;

namespace LabIProject.Test
{
    public class TaskTest : BaseTest<Task>
    {
        protected override Task SetupSystemUnderTest()
        {
            return new Task();
        }

        [Fact]
        public void Given_IsOnTrack_WhenTimeHasEpired_ShouldReturnFalse()
        {
            //Arrange
            SystemUnderTest.EstimationPropriety = 1;
            SystemUnderTest.StartDatePropriety= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 3);

            //Act
            var result = SystemUnderTest.IsOnTrack();

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Given_IsOnTrack_WhenTimeHasNotEpired_ShouldReturnTrue()
        {
            //Arrange
            SystemUnderTest.EstimationPropriety = 2 ;
            SystemUnderTest.StartDatePropriety = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);

            //Act
            var result = SystemUnderTest.IsOnTrack();

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Given_CalculateRemainingEstimate_WhenStartDateHasNotStarted_ShouldBeEqualToEstimation()
        {
            //Arrange
            SystemUnderTest.StartDatePropriety = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 10 );
            SystemUnderTest.EstimationPropriety = 10 ;

            //Act
            var result = SystemUnderTest.CalculateRemainingEstimate();

            //Assert
            result.Should().Be(SystemUnderTest.EstimationPropriety);
        }

        [Fact]
        public void Given_CalculateRemainingEstimate_WhenTaskHasStarted_ShouldReturnTheDifference()
        {
            //Arrange
            SystemUnderTest.StartDatePropriety = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 3); ;
            SystemUnderTest.EstimationPropriety = 10;

            //Act
            var result = SystemUnderTest.CalculateRemainingEstimate();

            //Assert
            result.Should().Be(SystemUnderTest.EstimationPropriety-3);
        }

        [Fact]
        public void Given_CalculateRemainingEstimate_WhenTasTimeHasExpired_Then_ShouldReturnZero()
        {
            //Arrange
            SystemUnderTest.StartDatePropriety = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day ); ;
            SystemUnderTest.EstimationPropriety = 10;

            //Act
            var result = SystemUnderTest.CalculateRemainingEstimate();

            //Assert
            result.Should().Be(0);
        }


    }
}