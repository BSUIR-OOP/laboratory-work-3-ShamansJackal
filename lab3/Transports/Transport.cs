using System;

namespace lab3.Transports
{
    public abstract class Transport
    {
        public string model { get; set; }

        public int power { get; set; }
        public int capacity { get; set; }
        public byte[] bin { get; set; }

        public string base64
        {
            get => Convert.ToBase64String(bin, 0, bin.Length);
            set => bin = Convert.FromBase64String(value);
        }
        public abstract string Move();
    }
}
