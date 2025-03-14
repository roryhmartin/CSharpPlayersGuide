﻿using System.ComponentModel.DataAnnotations.Schema;

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
    protected List<string> AvailableActions { get; } = new(); 
    
    public virtual string LocationName { get; set; }
    
    public Locations(Map map, string name, string locationSymbol, GameLogic gameLogic)
    {
        LocationName = name;
        Map = map;
        _locationSymbol = locationSymbol;
        GameLogic = gameLogic;
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

    public List<string> GetAvailableActions()
    {
        return AvailableActions;
    }
    
    public virtual void ExecuteAction(string action)
    {
        Console.WriteLine("No actions available at this location");
        return;
    }
    
}