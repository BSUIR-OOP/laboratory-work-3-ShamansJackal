using lab3.Interfaces;
using lab3.Struct;
using System;

namespace lab3.Transports
{
    public abstract class Transport : IJsonSerializeble, ICloneable
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

        public abstract string ClassName();

        public abstract object Clone();

        public abstract object FromJson(JsonToken json);

        public abstract string Move();

        public virtual string ToJson()
        {
            return $@"{{""power"":{power},""model"":""{model}"",""capacity"":{capacity},""base64"":""{base64}""}}";
        }
    }
}
