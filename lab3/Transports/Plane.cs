using lab3.Interfaces;
using lab3.Struct;

namespace lab3.Transports
{
    public class Plane: Transport
    {
        public override string Move() => $"Plane({model}) fly in sky";
        public string DoABarrerRoll() => $"Doing barrel roll...";

        public override object FromJson(JsonToken json)
        {
            var dict = json.ChildDict;
            return new Plane() {
                model = dict["model"].Content,
                power = int.Parse(dict["power"].Content),
                capacity = int.Parse(dict["capacity"].Content),
                base64 = dict["base64"].Content
            };
        }
        public override string ClassName() => "plane";

        public override object Clone()
        {
            return new Plane()
            {
                model = model,
                power = power,
                capacity = capacity,
                base64 = base64
            };
        }
    }
}
