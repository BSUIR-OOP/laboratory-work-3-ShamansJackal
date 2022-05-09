using lab3.Interfaces;
using lab3.Struct;

namespace lab3.Transports
{
    public class Tanker: Transport
    {
        public override string Move() => $"Tanker ship({model}) сrosses the sea";
        public string GetOil() => $"Geting oil from tanker: {capacity}L...";

        public override object FromJson(JsonToken json)
        {
            var dict = json.ChildDict;
            return new Tanker()
            {
                model = dict["model"].Content,
                power = int.Parse(dict["power"].Content),
                capacity = int.Parse(dict["capacity"].Content),
                base64 = dict["base64"].Content
            };
        }
        public override string ClassName() => "tanker";

        public override object Clone()
        {
            return new Tanker()
            {
                model = model,
                power = power,
                capacity = capacity,
                base64 = base64
            };
        }
    }
}
