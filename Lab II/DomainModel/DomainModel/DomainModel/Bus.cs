using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace DomainModel
{
    
    public class Bus
    {
        private List<RoadTrip> schedule_values;
        private const int MAXDISTANCE = 100;
        public Guid id { get; set; }

        public List<RoadTrip> schedule
        {
            get => schedule_values;
            set { schedule_values = value; } 

        }

        public int traveledDistance { get; set; }
        public bool isFullyScheduled { get; set; }


        public Bus()
        {
            isFullyScheduled = false;
            schedule=new List<RoadTrip>();
            id=new Guid();
        }
        public void AddRoadTrip(RoadTrip roadTrip)
        {
            if (isFullyScheduled)
            {
                throw new BusinessException("Bus is fully scheduled");
            }

            else if (MAXDISTANCE - traveledDistance < roadTrip.distance)
            {
                throw new BusinessException("This Road Trip exceds bus max milage");
            }

            else if (RoadTripOverlapsAnotherRoadTrip(roadTrip))
            {
                throw new BusinessException("This Road Trip has no room in bus schedule");
            }

            else if (roadTrip.distance > 50)
            {
                throw new BusinessException("The roadTrip connot be longer than 50 km");

            }
            else
            {
                schedule.Add(roadTrip);
                traveledDistance += roadTrip.distance;
               
                if (traveledDistance + roadTrip.distance == 100)
                {
                    isFullyScheduled = true;
                }
            }
            
        }

        public bool RoadTripOverlapsAnotherRoadTrip(RoadTrip roadTrip)
        {
            foreach(RoadTrip programedRoadTrip in schedule)
            {
                if (roadTrip.departureTime < programedRoadTrip.arrivalTime && programedRoadTrip.departureTime < roadTrip.arrivalTime)
                {
                    return true;
                }
            }
            return false;
        }



    }
}
