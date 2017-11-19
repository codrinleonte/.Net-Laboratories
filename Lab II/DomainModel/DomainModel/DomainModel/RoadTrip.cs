using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class RoadTrip
    {

        public int distance{get;set;}
        public TimeSpan departureTime { get; set; }
        public TimeSpan arrivalTime { get; set; }



        public TimeSpan GetRoadDuration()
        {
            return arrivalTime - departureTime;
        }
    }
}
