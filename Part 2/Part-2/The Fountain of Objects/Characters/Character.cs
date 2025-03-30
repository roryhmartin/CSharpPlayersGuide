namespace The_Fountain_of_Objects;

public abstract class Character
{
    protected int Row { get; set; }
    protected int Column { get; set; }
    protected Map Map { get; }
    private readonly string _icon;
    protected GetLocation _getLocation;
    protected virtual int Health { get; set; } = 100;
    protected virtual string Name { get; set; } = "default character name";

    protected virtual int AttackPower { get; set; } = 100;
    
    public Character(int row, int column, Map map, string icon)
    {
        Row = row;
        Column = column;
        Map = map;
        _icon = icon;
        _getLocation = new GetLocation(row, column);
    }
    
    public virtual void SetLocation(int row, int column)
    {
        Row = row;
        Column = column;
        _getLocation = new GetLocation(row, column);
        Map.SetCell(Row, Column, _icon);
    }
    
    public GetLocation GetLocation()
    {
        return _getLocation;
    } 
    
    public string GetIcon()
    {
        return _icon;
    }

    public string GetName()
    {
        return Name;
    }
    
    public int GetHealth()
    {
        return Health;
    }

    public void AddHealth(int amount)
    {
        Health += amount;
        
        Console.WriteLine($"{Name} healed for {amount}");
        Console.WriteLine($"{Name} total health is now {Health}");
    }

    public int ReduceHealth(int amount)
    {
        Health -= amount;
        
        if (Health <= 0)
        {
            Health = 0;
        }
        else
        {
            Console.WriteLine($"{Name} took {amount} damage.");
        }

        return Health;
    }
    
}