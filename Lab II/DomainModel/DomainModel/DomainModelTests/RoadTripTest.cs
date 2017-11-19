using System;
using DomainModel;
using LabIProject.Test;
using Xunit;
using FluentAssertions;

namespace DomainModelTests
{
    public class RoadTripTest : BaseTest<RoadTrip>
    {

        protected override RoadTrip SetupSystemUnderTest()
        {
            return new RoadTrip();
        }
        [Fact]
        public void GetRoadDurationTest_ShouldReturnEqual()
        {
            //Arrange
            SystemUnderTest.departureTime = new TimeSpan(9,0,10);
            SystemUnderTest.arrivalTime = new TimeSpan( 12, 0, 10); ;

            //Act
            var result = SystemUnderTest.GetRoadDuration();

            //Assert
            result.Should().Be(new TimeSpan(3, 0, 0));
        }



     
    }
}
