using lab3.Interfaces;
using lab3.Struct;
using System;

namespace lab3.Transports
{
    public class Jet : Transport
    {

        public override string Move() => $"Jet({model}) flying in sky";
        public string MoveAtSonicSpeed() => @"
       ___------__
 |\__-- /\       _-
 |/    __      -
 //\  /  \    /__
 |  o|  0|__     --_
 \\____-- __ \   ___-
 (@@    __/  / /_
    -_____---   --_
     //  \ \\   ___-
   //|\__/  \\  \
   \_-\_____/  \-\
        // \\--\| 
   ____//  ||_
  /_____\ /___\
______________________
";

        public override object FromJson(JsonToken json)
        {
            var dict = json.ChildDict;
            return new Jet()
            {
                model = dict["model"].Content,
                power = int.Parse(dict["power"].Content),
                capacity = int.Parse(dict["capacity"].Content),
                base64 = dict["base64"].Content
            };
        }

        public override string ClassName() => "jet";

        public override object Clone()
        {
            return new Jet()
            {
                model = model,
                power = power,
                capacity = capacity,
                base64 = base64
            };
        }
    }
}
