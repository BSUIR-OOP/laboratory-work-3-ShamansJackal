using lab3.Enum;

namespace lab3.Transports
{
    public class Plane: Transport
    {
        static Plane()
        {
            capacityType = CapacityType.Kilogram;
            powerType = EnginePowerType.HorsePowers;
        }

        public override string Move() => $"Plane({model}) fly in sky";
        public string DoABarrerRoll() => $"Doing barrel roll...";
    }
}
