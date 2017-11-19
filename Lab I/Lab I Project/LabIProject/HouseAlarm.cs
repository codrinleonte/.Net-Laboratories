using System;

namespace LabIProject
{
    public class HouseAlarm : Alarm
    {
        private const string DEFAULT_ADRESS = "No Adress";
        private string Adress;

        public HouseAlarm()
        {
            Id = Guid.NewGuid();
            Adress = DEFAULT_ADRESS;
            AlertTime = default(DateTime);
        }

        public HouseAlarm(string adress, DateTime alertTime)
        {
            Id = Guid.NewGuid();
            Adress = adress;
            AlertTime = alertTime;
        }


        public string AdressPropriety
        {
            get => Adress;
            set
            {
                if (value != null)
                    Adress = value;
                else
                    Adress = DEFAULT_ADRESS;
            }
        }

        public override string Trigger()
        {
            AlertTime = DateTime.Now;
            return "House alarm triggered at the adress " + Adress + " , calling cops.";
        }
    }
}