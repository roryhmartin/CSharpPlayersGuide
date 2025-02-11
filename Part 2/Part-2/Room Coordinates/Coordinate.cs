namespace Room_Coordinates;

public readonly struct Coordinate
{
    public int Row { get; }
    public int Column { get; }
    
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAdjacentTo(Coordinate a, Coordinate b)
    {
        int rowDiff = Math.Abs(a.Row - b.Row);
        int colDiff = Math.Abs(a.Column - b.Column);
        
        if ((rowDiff == 1 && colDiff == 0) || (colDiff == 1 && rowDiff == 0))
        {
            return true;
        }
        
        return false;
    }
    
}