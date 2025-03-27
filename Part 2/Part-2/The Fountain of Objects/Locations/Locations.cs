using System.ComponentModel.DataAnnotations.Schema;

namespace The_Fountain_of_Objects;

public class Locations
{
    private int _row;
    private int _column;
    private bool IsLocationDiscovered { get; set;  } = false;
    private string _locationNotDiscovered = " ";
    private string _locationSymbol;
    protected readonly Map Map;
    private GetLocation _getLocation;
    protected GameLogic GameLogic;
    public virtual string LocationName { get; set; }

    public Dictionary<int, (Action action, string description)> LocationDictionary = new Dictionary<int, (Action action, string description)>();
    
    public Locations(Map map, string name, string locationSymbol, GameLogic gameLogic)
    {
        LocationName = name;
        Map = map;
        _locationSymbol = locationSymbol;
        GameLogic = gameLogic;
        AddLocationActions();
    }

    public virtual void AddLocationActions()
    {
        LocationDictionary.Add(1, (LocationAction, "Location Description"));
    }
    
    public string GetLocationSymbol()
    {
        if (!IsLocationDiscovered)
        {
            return _locationNotDiscovered;
        }
        else
        {
            return _locationSymbol;
        }
    }
    
    public virtual void SetLocation (int row, int column)
    {
        _row = row;
        _column = column;
        
        if (IsLocationDiscovered)
        {
            Map.SetCell(row, column, _locationSymbol);
        }
        else
        {
            Map.SetCell(row, column, _locationNotDiscovered);
        }

        _getLocation = new GetLocation(row, column);
    }

    // public (int row, int column) GetLocation()
    // {
    //     return (_row, _column);
    // }

    public GetLocation GetLocation()
    {
        return _getLocation;
    }

    public virtual void LocationDiscovered()
    {
        IsLocationDiscovered = true;
        SetLocation(_row, _column);
    }

    public virtual void LocationDescription()
    {
        return;
    }
    
    public virtual void LocationAction()
    {
        Console.WriteLine("No actions available at this location");
        return;
    }
    
}