namespace Packing_Inventory_01;

public class Pack
{
    private int ItemTotal { get; set; }
    private int MaxWeight { get; set; }
    private int MaxVolume { get; set; }
    
    // public InventoryItem[] Items;
    
    public List<InventoryItem> Items { get; } = new List<InventoryItem>();
    
    public int CurrentTotalItems { get; protected set; }
    public int CurrentWeight { get; protected set; }
    public int CurrentVolume { get; protected set; }
    
    public Pack(int itemTotal, int maxWeight, int maxVolume)
    {
        ItemTotal = itemTotal;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }

    public bool Add(InventoryItem item)
    {
        if (!CanAddItems(item))
        {
            Console.WriteLine("Can't add item to inventory");
            return false;
        }

        CurrentTotalItems++;
        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;
        Items.Add(item);
        return true;
    }

    public bool CanAddItems(InventoryItem item)
    {
        if (CurrentTotalItems >= ItemTotal)
        {
            Console.WriteLine("Total items can't be more than item total");
            return false;
        }

        if (CurrentWeight >= MaxWeight)
        {
            Console.WriteLine("Adding item would exceed maximum weight");
            return false;
        }

        if (CurrentVolume >= MaxVolume)
        {
            Console.WriteLine("Adding item would exceed maximum volume");
            return false;
        }

        if (item.Weight + CurrentWeight > MaxWeight)
        {
            Console.WriteLine("Adding item would exceed maximum weight");
            return false;
        }

        if (item.Volume + CurrentVolume > MaxVolume)
        {
            Console.WriteLine("Adding item would exceed maximum volume");
            return false;
        }
        
        return true;
    }
    
    public void GetPackCapacity()
    {
        string packCapacity = $$"""
                                This pack can hold:
                                {{ItemTotal}} items.
                                Maximum weight is {{MaxWeight}}.
                                Maximum volume is {{MaxVolume}}.
                                """;

        Console.WriteLine(packCapacity);
    }


    public void GetCurrentPackContents()
    {
        string itemList = Items.Count > 0 ? string.Join(", ", Items.Select(i => i.ItemName)) : "Empty";
        
        // string itemList = Items.Count > 0 
        //     ? string.Join(", ", Items.Select(i => i.ItemName)) 
        //     : "Empty";
        
        Console.WriteLine($$"""
            Current Weight: {{CurrentWeight}} / {{MaxWeight}}
            Current Volume: {{CurrentVolume}} / {{MaxVolume}}
            Total Items: {{CurrentTotalItems}} / {{ItemTotal}}
            Current Items: {{itemList}} 
            """
            );
    }
}