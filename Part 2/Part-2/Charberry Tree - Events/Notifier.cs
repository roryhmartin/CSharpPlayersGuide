namespace Charberry_Tree___Events;

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnTreeRipened;
    }

    public void OnTreeRipened()
    {
        Console.WriteLine("The Tree has ripened.");
        Thread.Sleep(1000);
    }
}