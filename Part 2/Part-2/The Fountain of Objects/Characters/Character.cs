namespace The_Fountain_of_Objects;

public abstract class Character
{
    protected int Row { get; set; }
    protected int Column { get; set; }
    protected Map Map { get; }
    private readonly string _icon;
    protected GetLocation _getLocation;
    
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
}