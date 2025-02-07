namespace Packing_Inventory_01.derivedItems;

public class rope : InventoryItem
{
    public rope(int weight, int volume) : base(weight, volume)
    {
    }

    public override string ToString()
    {
        return "50ft of Rope";
    }
}