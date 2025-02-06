namespace Packing_Inventory_01.derivedItems;

public class Sword : InventoryItem
{
    public Sword(int weight, int volume, string name) : base(weight, volume)
    {
        ItemName = name;
        // quantity = 1;
    }
}