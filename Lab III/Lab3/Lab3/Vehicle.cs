using System;
using EnsureThat;

namespace Lab3
{
    public abstract class Vehicle
    {
        protected Vehicle()
        {
            Id = Guid.NewGuid();
        }

 
        public Guid Id { get; }
        public string Color { get; protected set; }

        public int HorsePower { get; protected set; }

        public int Consumption { get; protected set; }


        public virtual int ComputeFuelConsumption(int distance)
        {
            EnsureArg.IsGt(distance, 0);
            return Consumption * distance / 100;
        }

        public virtual string StartEngine()
        {
            return "Starting " + GetType().Name;
        }
    }
}