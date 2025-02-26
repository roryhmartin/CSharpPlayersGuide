using The_Fountain_of_Objects.Enumerations;

namespace The_Fountain_of_Objects;

public class Player : IPlayer
{
    private int _row;
    private int _column;
    private Map _map;
    private string _playerIcon = "@";
    
    
    public Player(int row, int column, Map map)
    {
        _row = row;
        _column = column;
        _map = map;
    }

    public virtual void SetPlayerLocation(int row, int column)
    {
        _row = row;
        _column = column;
        _map.SetCell(_row, _column, _playerIcon);
    }

    public string GetPlayerIcon()
    {
        return _playerIcon;
    }

    public bool IsValidMove()
    {
        var (maxRows, maxColumns) = _map.GetMapSize();

        if (_row < 0 || _row >= maxRows || _column < 0 || _column >= maxColumns)
        {
            return false;
        }

        return true;
    }

    public void Move()
    {
        Console.WriteLine("Choose a direction: North, East, South, West");

        string direction = Console.ReadLine().ToLower();

        int previousRows = _row;
        int previousColumns = _column;
        
        if (direction == "north")
        {
            _row--;
        }
        else if (direction == "east")
        {
            _column++;
        }
        else if (direction == "south")
        {
            _row++;
        }
        else if (direction == "west")
        {
            _column--;
        }
        else
        {
            Console.WriteLine("Invalid direction");
        }

        if (!IsValidMove())
        {
            _row = previousRows;
            _column = previousColumns;
            Console.WriteLine("You cannot go that way");
        }
        else
        {
            _map.SetCell(previousRows, previousColumns, " ");
           SetPlayerLocation(_row, _column);
        }
    }
}