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
    }
}
