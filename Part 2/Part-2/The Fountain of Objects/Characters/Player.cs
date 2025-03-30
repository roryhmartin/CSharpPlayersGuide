using The_Fountain_of_Objects.Enumerations;

namespace The_Fountain_of_Objects;

public class Player : Character, IPlayer
{
    private static string _icon = "@";
    protected override int Health { get; set; } = 100;

    public Player(int row, int column, Map map)
        : base(row, column, map, _icon)
    {
        Name = "Player 1";
    }

    public void SetPlayerLocation(int row, int column)
    {
        SetLocation(row, column);
    }

    public GetLocation GetPlayerLocation()
    {
        return GetLocation();
    } 
    
    // public (int Row, int Column) GetPlayerLocation()
    // {
    //     return (Row, Column);
    // }

    public string GetPlayerIcon()
    {
        return GetIcon();
    }

    public bool IsValidMove(int row, int column)
    {
        var (maxRows, maxColumns) = Map.GetMapSize();

        if (row < 0 || row >= maxRows || column < 0 || column >= maxColumns)
        {
            return false;
        }

        return true;
    }
}