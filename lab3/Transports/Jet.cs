using lab3.Enum;
using System;

namespace lab3.Transports
{
    public class Jet : Transport, ICloneable
    {
        static Jet()
        {
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
