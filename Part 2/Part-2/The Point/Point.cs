namespace The_Point;

public class Point
{
    public int X { get; }

    public int Y { get; }
    
    public Point(int x, int y )
    {
        X = x;
        Y = y;
    }
    
    public Point() : this(0, 0)
    {
    }
}