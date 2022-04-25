using lab3.Enum;

namespace lab3.Transports
{
    public class Plane: Transport
    {
        public Plane(string model, int power, int capacity)
        {
            this.capacity = capacity;
            this.model = model;
            this.power = power;

            capacityType = CapacityType.Kilogram;
            powerType = EnginePowerType.HorsePowers;
        }

        public override string Move() => $"Plane({model}) fly in sky";
        public string DoABarrerRoll() => $"Doing barrel roll...";
    }
}
