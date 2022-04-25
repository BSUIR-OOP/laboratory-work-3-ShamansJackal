using lab3.Enum;
using System.Text.Json.Serialization;

namespace lab3.Transports
{
    public abstract class Transport
    {
        public int power;
        [JsonIgnore]
        public EnginePowerType powerType;
        public int capacity;
        [JsonIgnore]
        public CapacityType capacityType;
        public string model;

        public abstract string Move();
    }
}
