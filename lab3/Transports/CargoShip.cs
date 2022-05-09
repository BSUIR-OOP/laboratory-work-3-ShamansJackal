namespace lab3.Transports
{
    public class CargoShip : Transport
    {
        public override string Move() => $"Cargo ship({model}) сrosses the sea";
        public string Unloading() => $"Unloading cargo...";
    }
}
