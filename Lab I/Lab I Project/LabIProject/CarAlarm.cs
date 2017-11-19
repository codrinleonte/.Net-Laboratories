using System;

namespace LabIProject
{
    public class CarAlarm : Alarm
    {
        private const string DEFAULT_LOCATION = "No Location";
        private string Location;

        public CarAlarm()
        {
            Id = Guid.NewGuid();
            LocationPropriety = DEFAULT_LOCATION;
            AlertTime = default(DateTime);
        }

        public CarAlarm(string location, DateTime alertTime)
        {
            Id = Guid.NewGuid();
            LocationPropriety = location;
            AlertTime = alertTime;
        }


        public string LocationPropriety
        {
            get => Location;
            set
            {
                if (value != null)
                    Location = value;
                else
                    Location = DEFAULT_LOCATION;
            }
        }

        public override string Trigger()
        {
            AlertTime = DateTime.Now;
            return string.Format("Car alarm activated at " + LocationPropriety + " calling cops.");
        }
    }
}