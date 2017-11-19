namespace Lab3
{
    public class Motorbike : Vehicle
    {
        private Motorbike()
        {
        }

        public string Model { get; private set; }

        public static Motorbike Create(string color, int horsePower, int consumption, string model)
        {
            return new Motorbike
            {
                Color = color,
                Consumption = consumption,
                HorsePower = horsePower,
                Model = model
            };
        }
    }
}