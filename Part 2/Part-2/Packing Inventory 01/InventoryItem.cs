namespace Packing_Inventory_01;

public class InventoryItem
{
    public string ItemName { get; set; }
    public int quantity { get; protected set; }
    public int Weight { get; }
    public int Volume { get; }
    
    public InventoryItem(int weight, int volume)
    {
        Weight = weight;
        Volume = volume;
    }

    public string getItemName()
    {
        return ItemName;
    }

    public int getQuantity()
    {
        return quantity;
    }
}