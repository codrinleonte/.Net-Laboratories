using System;
namespace LabIProject
{
    public abstract class Alarm
    {
       
        protected DateTime AlertTime;
        protected Guid Id;


        public Guid IdPropriety
        {
            get => Id;
            private set
            {
                if (value != null)
                    Id = value;
            }
        }

        public DateTime AlertTimePropriety
        {
            get => AlertTime;
            set
            {
                if (value != null)
                    AlertTime = value;
            }
        }

        
        public abstract string Trigger();
       
    }
}
