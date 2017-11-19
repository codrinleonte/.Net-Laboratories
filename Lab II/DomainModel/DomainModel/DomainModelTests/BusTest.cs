using System;
using System.Collections.Generic;
using DomainModel;
using LabIProject.Test;
using Xunit;
using FluentAssertions;

namespace DomainModelTests
{
    public class BusTest : BaseTest<Bus>
    {
       

        protected override Bus SetupSystemUnderTest()
        {
            return new Bus();
        }
        [Fact]
        public void RoadTripOverlapsAnotherRoadTrip_RoadTripNotOverlapingSchedule_ShouldReturnFalse()
        {
            //Arrange
            
            RoadTrip firstRoadTrip = new RoadTrip();
            firstRoadTrip.departureTime = new TimeSpan(4,10,0);
            firstRoadTrip.arrivalTime = new TimeSpan(5,10,0);

            RoadTrip secondRoadTrip = new RoadTrip();
            secondRoadTrip.departureTime = new TimeSpan(6, 10, 0);
            secondRoadTrip.arrivalTime = new TimeSpan(7, 10, 0);

            List<RoadTrip> roadList = new List<RoadTrip>();
            roadList.Add(firstRoadTrip);
            roadList.Add(secondRoadTrip);

            SystemUnderTest.schedule = roadList;


            RoadTrip overlappingRoadTrip = new RoadTrip();
            overlappingRoadTrip.departureTime  = new TimeSpan(12, 20, 0);
            overlappingRoadTrip.departureTime =  new TimeSpan(14, 20, 0);
            //Act
            var result = SystemUnderTest.RoadTripOverlapsAnotherRoadTrip(overlappingRoadTrip);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void RoadTripOverlapsAnotherRoadTrip_RoadTripOverlapsSchedule_ShouldReturnTrue()
        {
            //Arrange
         
            RoadTrip firstRoadTrip = new RoadTrip();
            firstRoadTrip.departureTime = new TimeSpan(4, 10, 0);
            firstRoadTrip.arrivalTime = new TimeSpan(5, 10, 0);

            RoadTrip secondRoadTrip = new RoadTrip();
            secondRoadTrip.departureTime = new TimeSpan(6, 10, 0);
            secondRoadTrip.arrivalTime = new TimeSpan(7, 10, 0);

            List<RoadTrip> roadList = new List<RoadTrip>();
            roadList.Add(firstRoadTrip);
            roadList.Add(secondRoadTrip);

            SystemUnderTest.schedule = roadList;


            RoadTrip overlappingRoadTrip = new RoadTrip();
            overlappingRoadTrip.departureTime = new TimeSpan(6, 20, 0);
            overlappingRoadTrip.arrivalTime = new TimeSpan(8, 20, 0);
            //Act
            var result = SystemUnderTest.RoadTripOverlapsAnotherRoadTrip(overlappingRoadTrip);

            //Assert
            result.Should().BeTrue();
        }



        [Fact]
        public void AddRoadTrip_RoadTripOverlapingSchedule_ShouldThrowBusinessException()
        {
            //Arrange
            
            RoadTrip firstRoadTrip = new RoadTrip();
            firstRoadTrip.departureTime = new TimeSpan(4, 10, 0);
            firstRoadTrip.arrivalTime = new TimeSpan(5, 10, 0);

            RoadTrip secondRoadTrip = new RoadTrip();
            secondRoadTrip.departureTime = new TimeSpan(6, 10, 0);
            secondRoadTrip.arrivalTime = new TimeSpan(7, 10, 0);

            List<RoadTrip> roadList = new List<RoadTrip>();
            roadList.Add(firstRoadTrip);
            roadList.Add(secondRoadTrip);

            SystemUnderTest.schedule = roadList;
             
        
            RoadTrip overlappingRoadTrip = new RoadTrip();
            overlappingRoadTrip.departureTime = new TimeSpan(5, 20, 0);
            overlappingRoadTrip.arrivalTime = new TimeSpan(8, 20, 0);
            //Act
          AssertionExtensions.ShouldThrow<BusinessException>(() => SystemUnderTest.AddRoadTrip(overlappingRoadTrip));
        }

        [Fact]
        public void AddRoadTrip_RoadTripNonOverlapingSchedule_ShouldNotThrowBusinessException()
        {
            //Arrange
            
            RoadTrip firstRoadTrip = new RoadTrip();
            firstRoadTrip.departureTime = new TimeSpan(4, 10, 0);
            firstRoadTrip.arrivalTime = new TimeSpan(5, 10, 0);

            RoadTrip secondRoadTrip = new RoadTrip();
            secondRoadTrip.departureTime = new TimeSpan(6, 10, 0);
            secondRoadTrip.arrivalTime = new TimeSpan(7, 10, 0);

            List<RoadTrip> roadList = new List<RoadTrip>();
            roadList.Add(firstRoadTrip);
            roadList.Add(secondRoadTrip);

            SystemUnderTest.schedule = roadList;


            RoadTrip nonOverlappingRoadTrip = new RoadTrip();
            nonOverlappingRoadTrip.departureTime = new TimeSpan(10, 20, 0);
            nonOverlappingRoadTrip.departureTime = new TimeSpan(11, 20, 0);
            //Act
            AssertionExtensions.ShouldNotThrow<BusinessException>(() => SystemUnderTest.AddRoadTrip(nonOverlappingRoadTrip));
        }

        [Fact]
        public void AddRoadTrip_WhenBusIsFullyScheduled_ShouldThrowBusinessException()
        {
            //Arrange
           
            SystemUnderTest.isFullyScheduled = true;
            
            RoadTrip roadTrip = new RoadTrip();
            roadTrip.departureTime = new TimeSpan(10, 20, 0);
            roadTrip.departureTime = new TimeSpan(11, 20, 0);
            //Act
            AssertionExtensions.ShouldThrow<BusinessException>(() => SystemUnderTest.AddRoadTrip(roadTrip));
        }


        [Fact]
        public void AddRoadTrip_WhenBusMilageExceds_ShouldThrowBusinessException()
        {
            //Arrange
           
            RoadTrip firstRoadTrip = new RoadTrip();
            firstRoadTrip.departureTime = new TimeSpan(4, 10, 0);
            firstRoadTrip.arrivalTime = new TimeSpan(5, 10, 0);
            firstRoadTrip.distance = 40;
            RoadTrip secondRoadTrip = new RoadTrip();
            secondRoadTrip.departureTime = new TimeSpan(6, 10, 0);
            secondRoadTrip.arrivalTime = new TimeSpan(7, 10, 0);
            secondRoadTrip.distance = 50;
            List<RoadTrip> roadList = new List<RoadTrip>();
            roadList.Add(firstRoadTrip);
            roadList.Add(secondRoadTrip);

            SystemUnderTest.AddRoadTrip(firstRoadTrip);
            SystemUnderTest.AddRoadTrip(secondRoadTrip);

            RoadTrip excedingDistanceRoadTrip = new RoadTrip();
            excedingDistanceRoadTrip.departureTime = new TimeSpan(10, 20, 0);
            excedingDistanceRoadTrip.arrivalTime = new TimeSpan(11, 20, 0);
            excedingDistanceRoadTrip.distance = 20;
            //Act
            AssertionExtensions.ShouldThrow<BusinessException>(() => SystemUnderTest.AddRoadTrip(excedingDistanceRoadTrip));
        }


        [Fact]
        public void AddRoadTrip_WhenAllCondiontsAreFullfield_ShouldNotThrowBusinessException()
        {
            //Arrange
            
            RoadTrip firstRoadTrip = new RoadTrip();
            firstRoadTrip.departureTime = new TimeSpan(4, 10, 0);
            firstRoadTrip.arrivalTime = new TimeSpan(5, 10, 0);
            firstRoadTrip.distance = 40;
            RoadTrip secondRoadTrip = new RoadTrip();
            secondRoadTrip.departureTime = new TimeSpan(6, 10, 0);
            secondRoadTrip.arrivalTime = new TimeSpan(7, 10, 0);
            secondRoadTrip.distance = 50;
            List<RoadTrip> roadList = new List<RoadTrip>();
            roadList.Add(firstRoadTrip);
            roadList.Add(secondRoadTrip);

            SystemUnderTest.AddRoadTrip(firstRoadTrip);
            SystemUnderTest.AddRoadTrip(secondRoadTrip);

            RoadTrip thirdRoadTrip = new RoadTrip();
            thirdRoadTrip.departureTime = new TimeSpan(10, 20, 0);
            thirdRoadTrip.arrivalTime = new TimeSpan(11, 20, 0);
            thirdRoadTrip.distance = 5;
            //Act
            AssertionExtensions.ShouldNotThrow<BusinessException>(() => SystemUnderTest.AddRoadTrip(thirdRoadTrip));
        }
    }
}
