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
        _getLocation = new GetLocation(row, column);
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

    public bool IsValidMove(int row, int column)
    {
        var (maxRows, maxColumns) = _map.GetMapSize();

        if (row < 0 || row >= maxRows || column < 0 || column >= maxColumns)
        {
            return false;
        }

        return true;
    }
}