using System;

namespace Model
{
    public class Car
    {
        private Car()
        {
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public bool IsElectric { get; set; }

        public static Car Create(string name, bool isElectric)
        {
            var instance = new Car {Id = Guid.NewGuid()};
            instance.Update(name, isElectric);
            return instance;
        }

        public void Update(string name, bool isElectric)
        {
            Name = name;
            IsElectric = isElectric;
        }
    }
}