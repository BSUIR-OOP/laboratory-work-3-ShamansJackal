using lab3.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Transports
{
    public class CargoShip : Transport
    {
        static CargoShip()
        {
            capacityType = CapacityType.Kilogram;
            powerType = EnginePowerType.HorsePowers;
        }

        public override string Move() => $"Cargo ship({model}) сrosses the sea";
        public string Unloading() => $"Unloading cargo: {capacity} {System.Enum.GetName(typeof(CapacityType), capacityType)}";
    }
}
