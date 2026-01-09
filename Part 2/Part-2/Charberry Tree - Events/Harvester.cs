namespace Charberry_Tree___Events;

public class Harvester
{
    private int _harvestCount = 0;
    private CharberryTree _tree;
    
    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened()
    {
        _harvestCount++;
        _tree.Ripe = false;
        Console.WriteLine($"The tree has been harvested {_harvestCount} times.");
        Thread.Sleep(1000);
    }
}