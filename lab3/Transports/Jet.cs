using lab3.Enum;

namespace lab3.Transports
{
    public class Jet : Transport
    {
        public Jet(string model, int power, int capacity)
        {
            this.capacity = capacity;
            this.model = model;
            this.power = power;

            capacityType = CapacityType.People;
            powerType = EnginePowerType.KgS;
        }

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
    }
}
