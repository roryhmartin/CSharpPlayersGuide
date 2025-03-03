namespace The_Fountain_of_Objects;

public class GetLocation
{
    public int Row { get; set; }
    public int Column { get; set; }

    public GetLocation(int row, int column)
    {
        Row = row;
        Column = column;
    }
}