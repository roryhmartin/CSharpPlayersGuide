using System.ComponentModel.DataAnnotations.Schema;

namespace The_Fountain_of_Objects;

public class Locations
{
    private int _row;
    private int _column;
    private bool _isLocationDiscovered = false;
    private string _locationSymbol = " ";
    private Map _map;
    
    public virtual string LocationName { get; set; }
    
    public Locations(Map map, string name)
    {
        LocationName = name;
        _map = map;
    }

    public virtual void SetLocation (int row, int column, string value)
    {
        if (_isLocationDiscovered)
        {
            _locationSymbol = value;
            _map.SetCell(row, column, _locationSymbol);
        }
        else
        {
            _locationSymbol = " ";
            _map.SetCell(row, column, _locationSymbol);
        }
    }

    public virtual void LocationDiscovered()
    {
        _isLocationDiscovered = true;
    }
}