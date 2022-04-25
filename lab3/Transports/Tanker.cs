using lab3.Enum;

namespace lab3.Transports
{
    public class Tanker: Transport
    {
        static Tanker()
        {
            capacityType = CapacityType.Liter;
            powerType = EnginePowerType.HorsePowers;
        }

        public override string Move() => $"Tanker ship({model}) сrosses the sea";
        public string GetOil() => $"Geting oil from tanker: {capacity} {System.Enum.GetName(typeof(CapacityType), capacityType)}";
    }
}
