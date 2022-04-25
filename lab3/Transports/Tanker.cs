using lab3.Enum;

namespace lab3.Transports
{
    public class Tanker: Transport
    {
        public Tanker(string model, int power, int capacity)
        {
            this.capacity = capacity;
            this.model = model;
            this.power = power;

            capacityType = CapacityType.Kilogram;
            powerType = EnginePowerType.HorsePowers;
        }

        public override string Move() => $"Tanker ship({model}) сrosses the sea";
        public string GetOil() => $"Geting oil from tanker: {capacity} {System.Enum.GetName(typeof(CapacityType), capacityType)}";
    }
}
