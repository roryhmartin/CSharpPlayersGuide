using The_Fountain_of_Objects.Enumerations;

namespace The_Fountain_of_Objects;

public class Player : IPlayer
{
    private int Row { get; set; }
    private int Column { get; set; }
    private Map _map;
    private string _playerIcon = "@";
    private GetLocation _getLocation;
    
    
    public Player(int row, int column, Map map)
    {
        _getLocation = new GetLocation(row, column);
        _map = map;
    }

    public virtual void SetPlayerLocation(int row, int column)
    {
        Row = row;
        Column = column;
        _map.SetCell(Row, Column, _playerIcon);
    }

    public GetLocation GetPlayerLocation()
    {
        return _getLocation;
    } 
    
    // public (int Row, int Column) GetPlayerLocation()
    // {
    //     return (Row, Column);
    // }

    public string GetPlayerIcon()
    {
        return _playerIcon;
    }

    public bool IsValidMove()
    {
        var (maxRows, maxColumns) = _map.GetMapSize();

        if (Row < 0 || Row >= maxRows || Column < 0 || Column >= maxColumns)
        {
            return false;
        }

        return true;
    }

    public void Move()
    {
        Console.WriteLine("Choose a direction: North, East, South, West");

        string direction = Console.ReadLine().ToLower();

        int previousRows = Row;
        int previousColumns = Column;
        
        if (direction == "north")
        {
            Row--;
        }
        else if (direction == "east")
        {
            Column++;
        }
        else if (direction == "south")
        {
            Row++;
        }
        else if (direction == "west")
        {
            Column--;
        }
        else
        {
            Console.WriteLine("Invalid direction");
        }

        if (!IsValidMove())
        {
            Row = previousRows;
            Column = previousColumns;
            Console.WriteLine("You cannot go that way");
        }
        else
        {
            _map.SetCell(previousRows, previousColumns, " ");
           SetPlayerLocation(Row, Column);
        }
    }
}