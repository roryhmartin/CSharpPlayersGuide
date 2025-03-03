using System.ComponentModel.DataAnnotations.Schema;

namespace The_Fountain_of_Objects;

public class Locations
{
    private int _row;
    private int _column;
    private bool _isLocationDiscovered = false;
    private string _locationNotDiscovered = " ";
    private string _locationSymbol;
    private Map _map;
    private GetLocation _getLocation;
    
    public virtual string LocationName { get; set; }
    
    public Locations(Map map, string name, string locationSymbol)
    {
        LocationName = name;
        _map = map;
        _locationSymbol = locationSymbol;
    }
        
    public string GetLocationSymbol()
    {
        if (!_isLocationDiscovered)
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
        
        if (_isLocationDiscovered)
        {
            _map.SetCell(row, column, _locationSymbol);
        }
        else
        {
            _map.SetCell(row, column, _locationNotDiscovered);
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
        _isLocationDiscovered = true;
        SetLocation(_row, _column);
    }
}