namespace lab3.Transports
{
    public class Plane: Transport
    {
        public override string Move() => $"Plane({model}) fly in sky";
        public string DoABarrerRoll() => $"Doing barrel roll...";
    }
}
