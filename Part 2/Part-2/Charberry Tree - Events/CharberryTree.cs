namespace Charberry_Tree___Events;

public class CharberryTree
{
    public event Action? Ripened;
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public void MaybeGrow()
    {
        if (_random.NextDouble() < 0.0000001 && !Ripe)
        {
            Ripe = true;
            Ripened();
        }
    }
}