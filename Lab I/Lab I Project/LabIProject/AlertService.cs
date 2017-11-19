using System;
using System.Collections.Generic;

namespace LabIProject
{
    public class AlertService : IAlertSerciveInterface
    {
        private List<Alarm> alarmList;
        public AlertService()
        {
            AlarmListPopulation();
        }

        public List<Alarm> AlarmListPropriety
        {
            get => alarmList;
            set
            {
                alarmList = new List<Alarm>(value);
            }
        }
        public void AlarmListPopulation()
        {
            var firstAlarm = new HouseAlarm();
            var secondAlarm = new CarAlarm();
            var thirdAlarm = new HouseAlarm();

            firstAlarm.AdressPropriety = "Casa1";
            secondAlarm.LocationPropriety = "Locatie1";
            thirdAlarm.AdressPropriety = "Casa3";

            alarmList.Add(firstAlarm);
            alarmList.Add(secondAlarm);
            alarmList.Add(thirdAlarm);

           
        }

        public string SoundAlarm(Guid id)
        {
            var result = "";
            for (var i = 0; i < alarmList.Count; i++)
                if (alarmList[i].IdPropriety == id)
                    result += alarmList[i].Trigger();
            return result;
        }
    }
}