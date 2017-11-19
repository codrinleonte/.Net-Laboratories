using System;

namespace LabIProject
{
    internal interface IAlertSerciveInterface
    {
        void AlarmListPopulation();
        string SoundAlarm(Guid id);
    }
}