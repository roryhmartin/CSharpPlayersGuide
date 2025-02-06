namespace Packing_Inventory_01.derivedItems;

public class Bow : InventoryItem
{
    public Bow(int weight, int volume) : base(weight, volume)
    {
        ItemName = "Bow";
    }
}