namespace Lab3
{
    public class Car : Vehicle
    {
        private Car()
        {
        }

        public int NumberOfDoors { get; private set; }
        public int TrunkCapacity { get; private set; }

        public static Car Create(string color, int horsePower, int consumption, int numberOfDoors, int trunkCapacity)
        {
            return new Car
            {
                Color = color,
                Consumption = consumption,
                HorsePower = horsePower,
                NumberOfDoors = numberOfDoors,
                TrunkCapacity = trunkCapacity
            };
        }
    }
}