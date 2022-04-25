using lab3.Enum;
using System;
using System.Text.Json.Serialization;

namespace lab3.Transports
{
    public abstract class Transport : ICloneable
    {
        public string model { get; set; }

        public int power { get; set; }
        public int capacity { get; set; }

        [JsonIgnore]
        public byte[] bin { get; set; }

        public string base64
        {
            get => Convert.ToBase64String(bin, 0, bin.Length);
            set => bin = Convert.FromBase64String(value);
        }

        public static CapacityType capacityType;
        public static EnginePowerType powerType;

        public abstract string Move();

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
