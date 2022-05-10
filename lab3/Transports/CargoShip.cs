using lab3.Interfaces;
using lab3.Struct;

namespace lab3.Transports
{
    public class CargoShip : Transport
    {
        public string Unloading() => $"Unloading cargo...";
        public override string Move() => $"Cargo ship({model}) сrosses the sea";
        public override object FromJson(JsonToken json)
        {
            var dict = json.ChildDict;
            return new CargoShip()
            {
                model = dict["model"].Content,
                power = int.Parse(dict["power"].Content),
                capacity = int.Parse(dict["capacity"].Content),
                base64 = dict["base64"].Content
            };
        }
        public override string ClassName() => "cargoShip";

        public override object Clone()
        {
            return new CargoShip()
            {
                model = model,
                power = power,
                capacity = capacity,
                base64 = base64
            }; ;
        }
    }
}
